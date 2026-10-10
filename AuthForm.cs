using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AuthCAPTCHAImportCSV
{
    public partial class AuthForm : Form
    {
        private int failedAttempts = 0;
        private bool isProcessing = false;
        private readonly Random rnd = new Random();

        private readonly Timer inactivityTimer = new Timer();

        // Список CAPTCHA: картинка + правильный ответ
        private readonly List<(Image Image, string Answer)> captchas;
        private (Image Image, string Answer) currentCaptcha;

        // Показывать ли CAPTCHA (появляется после 1-й неудачной попытки)
        private bool captchaVisible = false;

        public AuthForm()
        {
            InitializeComponent();
            this.FormClosing += AuthForm_FormClosing;

            captchas = new List<(Image, string)>
            {
                (Properties.Resources.Captcha1, "8914"),
                (Properties.Resources.Captcha2, "WEJL"),
                (Properties.Resources.Captcha3, "1341"),
                (Properties.Resources.Captcha4, "HYIT")
            };

            inactivityTimer.Interval = GlobalConfig.InactivitySeconds * 1000;
            inactivityTimer.Tick += InactivityTimer_Tick;
            ResetInactivityTimer();

            this.MouseMove += (s, e) => ResetInactivityTimer();
            this.KeyDown += (s, e) => ResetInactivityTimer();

            // CAPTCHA изначально скрыта
            SetCaptchaVisible(false);

            // Кнопка «Обновить CAPTCHA»
            button_reboot.Click += (s, e) => ShowRandomCaptcha();
        }

        // ---------------- Таймер бездействия ----------------

        private void ResetInactivityTimer()
        {
            inactivityTimer.Stop();
            inactivityTimer.Start();
        }

        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            inactivityTimer.Stop();
            if (!Visible) return;

            MessageBox.Show("Сеанс заблокирован из-за неактивности.",
                "Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowLoginForm();
        }

        // ---------------- Закрытие формы ----------------

        private void AuthForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Закрыть?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                ShowLoginForm();
            }
        }

        // ---------------- Управление состоянием формы ----------------

        private void SetControlsEnabled(bool enabled)
        {
            loginTextBox.Enabled = enabled;
            passwordTextBox.Enabled = enabled;
            loginButton.Enabled = enabled;
            guestButton.Enabled = enabled;
            // cancelButton всегда активна — это «выход»
        }

        private void SetCaptchaVisible(bool visible)
        {
            captchaVisible = visible;
            label_Captcha.Visible = visible;
            pictureBox1.Visible = visible;
            pictureBox1.Visible = visible;
            button_reboot.Visible = visible;

            if (visible) ShowRandomCaptcha();
        }

        private void ShowRandomCaptcha()
        {
            currentCaptcha = captchas[rnd.Next(captchas.Count)];
            pictureBox1.Image = currentCaptcha.Image;
            textBox1.Clear();
            textBox1.Focus();
        }

        private void ShowLoginForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
            Activate();

            loginTextBox.Clear();
            passwordTextBox.Clear();
            textBox1.Clear();
            textBox1.Enabled = true;
            failedAttempts = 0;
            isProcessing = false;
            SetControlsEnabled(true);
            SetCaptchaVisible(false); // CAPTCHA снова скрыта
            loginTextBox.Focus();
            ResetInactivityTimer();
        }

        // ---------------- Кнопки ----------------

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы хотите сделать резервное копирование?",
                   "Запрос на резервное копирование",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                BackUpForm back = new BackUpForm();
                back.ShowDialog();
            }
            else
            {
                MessageBox.Show("Переход отменён.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.FormClosing -= AuthForm_FormClosing;
            Close();
        }

        private void guestButton_Click(object sender, EventArgs e)
        {
            GlobalConfig.UserRole = 3;
            GlobalConfig.IsGuest = true;
            GlobalConfig.UserFIO = $"Гостевой режим — {DateTime.Now:dd.MM.yyyy}";

            Hide();
            inactivityTimer.Stop();
            using (var f = new SelectProductForm()) f.ShowDialog();
            GlobalConfig.IsGuest = false;
            ShowLoginForm();
        }

        // ---------------- Вход ----------------

        private async void loginButton_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;
            SetControlsEnabled(false);

            string login = loginTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            // 1. Проверка CAPTCHA, если она показана
            if (captchaVisible)
            {
                string captchaInput = textBox1.Text.Trim();
                if (!captchaInput.Equals(currentCaptcha.Answer, StringComparison.OrdinalIgnoreCase))
                {
                    // CAPTCHA введена неверно
                    MessageBox.Show("CAPTCHA введена неправильно.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Блокировка на 10 секунд: всё, кроме «Отмена»
                    await BlockForSecondsAsync(10);

                    // Новая CAPTCHA
                    ShowRandomCaptcha();

                    SetControlsEnabled(true);
                    isProcessing = false;
                    return;
                }
            }

            // 2. Проверка логина и пароля в БД
            var user = GetUser(login, password);

            if (user == null)
            {
                failedAttempts++;

                // Проверяем отдельно логин и пароль, чтобы дать точное сообщение
                bool loginExists = LoginExists(login);
                if (!loginExists)
                    MessageBox.Show("Логин введён неправильно.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Пароль введён неправильно.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // После 1-й ошибки — показываем CAPTCHA (но НЕ блокируем)
                if (!captchaVisible)
                {
                    SetCaptchaVisible(true);
                    SetControlsEnabled(true);
                    isProcessing = false;
                    return;
                }

                // Если CAPTCHA уже была показана, а пользователь снова ошибся —
                // блокировка 10 сек и новая CAPTCHA
                await BlockForSecondsAsync(10);
                ShowRandomCaptcha();

                SetControlsEnabled(true);
                isProcessing = false;
                return;
            }

            // 3. Успешный вход
            GlobalConfig.UserRole = user.Value.RoleId;
            GlobalConfig.UserFIO = user.Value.FIO;
            GlobalConfig.IsGuest = false;
            failedAttempts = 0;
            inactivityTimer.Stop();

            Hide();
            bool returnToLogin = false;

            switch (user.Value.RoleId)
            {
                case 1:
                    using (var f = new DbConnectionForm()) f.ShowDialog();
                    returnToLogin = true;
                    break;
                case 2:
                    using (var f = new ManagerForm()) f.ShowDialog();
                    returnToLogin = true;
                    break;
                case 3:
                    using (var f = new SelectProductForm()) f.ShowDialog();
                    returnToLogin = true;
                    break;
            }

            if (returnToLogin) ShowLoginForm();
            else Close();
        }

        /// <summary>
        /// Блокирует все поля, кроме «Отмена», на N секунд.
        /// </summary>
        private async Task BlockForSecondsAsync(int seconds)
        {
            SetControlsEnabled(false);
            // cancelButton оставляем активной
            cancelButton.Enabled = true;
            textBox1.Enabled = false;

            MessageBox.Show($"Поля заблокированы на {seconds} секунд.",
                "Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await Task.Delay(seconds * 1000);

            textBox1.Enabled = true;
        }

        // ---------------- Работа с БД ----------------

        private (int RoleId, string FIO)? GetUser(string login, string password)
        {
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(
                        "SELECT UserRole, UserSurname, UserName, UserPatronymic " +
                        "FROM `user` WHERE UserLogin=@l AND UserPassword=@p", conn))
                    {
                        cmd.Parameters.AddWithValue("@l", login);
                        cmd.Parameters.AddWithValue("@p", password);

                        using (var r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                int role = r.GetInt32(0);
                                string fio = $"{r.GetString(1)} {r.GetString(2)} {r.GetString(3)}".Trim();
                                return (role, fio);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к БД: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private bool LoginExists(string login)
        {
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(
                        "SELECT COUNT(*) FROM `user` WHERE UserLogin=@l", conn))
                    {
                        cmd.Parameters.AddWithValue("@l", login);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}