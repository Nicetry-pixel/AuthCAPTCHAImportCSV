using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthCAPTCHAImportCSV
{
    public static class PersonalDataProtector
    {
        /// <summary>
        /// Маскирует ФИО: "Иванов Иван Иванович" → "Иванов И.И."
        /// </summary>
        public static string MaskFIO(string fio)
        {
            if (string.IsNullOrWhiteSpace(fio)) return "";

            var parts = fio.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 1) return parts[0];

            string result = parts[0];
            for (int i = 1; i < parts.Length; i++)
                result += " " + parts[i].Substring(0, 1).ToUpper() + ".";

            return result;
        }

        /// <summary>
        /// Маскирует телефон: "+7 (819) 753-5371" → "+7 (***) ***-****"
        /// </summary>
        public static string MaskPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return "";
            return System.Text.RegularExpressions.Regex.Replace(phone, @"\d", "*");
        }

        /// <summary>
        /// Маскирует адрес: "г. Вологда, ул. Чехова, д. 1" → "г. Вологда, ***"
        /// </summary>
        public static string MaskAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address)) return "";
            int comma = address.IndexOf(',');
            if (comma < 0) return address.Substring(0, Math.Min(4, address.Length)) + "***";
            return address.Substring(0, comma + 1) + " ***";
        }

        /// <summary>
        /// Маскирует email: "user@mail.ru" → "u***@mail.ru"
        /// </summary>
        public static string MaskEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return "";
            int at = email.IndexOf('@');
            if (at <= 1) return email;
            return email.Substring(0, 1) + "***" + email.Substring(at);
        }
    }
}
