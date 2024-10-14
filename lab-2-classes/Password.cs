using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab_2_classes
{
    // Класс для работы с паролями
    public class Password
    {
        protected string password;

        // Конструктор класса Password, инициализирует пароль
        public Password(string password)
        {
            this.password = password;
        }

        // Метод для проверки правильности введенного пароля
        public void CheckPassword(string input)
        {
            if (input == password)
            {
                MessageBox.Show("Пароль верный");
            }
            else
            {
                MessageBox.Show("Пароль неверный");
            }
        }
    }

    // Класс для работы с сильными паролями, наследуется от Password
    public class StrongPassword : Password
    {
        // Конструктор класса StrongPassword, вызывает конструктор базового класса
        public StrongPassword(string password) : base(password)
        {
        }

        /// <summary>
        /// Анализирует надежность пароля.
        /// </summary>
        /// <param name="personalInfo">Список личной информации пользователя</param>
        /// <param name="message">Выходное сообщение с результатами анализа</param>
        /// <returns>Возвращает true, если пароль надежный, иначе false</returns>
        public bool AnalyzePasswordStrength(List<string> personalInfo, out string message)
        {
            string password = this.password;
            List<string> messages = new List<string>();
            bool isStrong = true;

            // 1. Проверка длины пароля (должен быть больше 12 символов)
            if (password.Length <= 12)
            {
                messages.Add("Пароль должен быть длиннее 12 символов.");
                isStrong = false;
            }

            // 2. Проверка наличия различных типов символов
            if (!password.Any(char.IsLower))
            {
                messages.Add("Пароль должен содержать строчные буквы.");
                isStrong = false;
            }
            if (!password.Any(char.IsUpper))
            {
                messages.Add("Пароль должен содержать прописные буквы.");
                isStrong = false;
            }
            if (!password.Any(char.IsDigit))
            {
                messages.Add("Пароль должен содержать цифры.");
                isStrong = false;
            }
            if (!password.Any(c => !char.IsLetterOrDigit(c)))
            {
                messages.Add("Пароль должен содержать символы.");
                isStrong = false;
            }

            // 3. Проверка на наличие последовательностей символов с клавиатуры
            if (ContainsKeyboardSequence(password))
            {
                messages.Add("Пароль не должен содержать последовательности символов, расположенных рядом на клавиатуре.");
                isStrong = false;
            }

            // 4. Проверка на отсутствие личной информации в пароле
            foreach (var info in personalInfo)
            {
                if (!string.IsNullOrEmpty(info) && password.ToLower().Contains(info.ToLower()))
                {
                    messages.Add($"Пароль не должен содержать личную информацию: {info}");
                    isStrong = false;
                }
            }

            // Формирование итогового сообщения
            if (isStrong)
            {
                message = "Пароль надёжный.";
            }
            else
            {
                message = string.Join("\n", messages);
            }

            return isStrong;
        }

        /// <summary>
        /// Проверяет, содержит ли пароль последовательности символов, расположенных рядом на клавиатуре.
        /// </summary>
        /// <param name="password">Пароль для проверки</param>
        /// <returns>Возвращает true, если найдена последовательность, иначе false</returns>
        private bool ContainsKeyboardSequence(string password)
        {
            // Определение последовательностей символов на клавиатуре
            string[] sequences = new string[]
            {
                "1234567890",
                "qwertyuiop",
                "asdfghjkl",
                "zxcvbnm",
                "!@#$%^&*()_+",
                "`1234567890-=",
                "~!@#$%^&*()_+",
                "1qaz2wsx3edc",
                "qazwsxedc",
                "abcdefghijklmnopqrstuvwxyz", 
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            };

            string pwdLower = password.ToLower();

            // Проверка наличия любой из последовательностей в пароле
            foreach (var seq in sequences)
            {
                for (int i = 0; i < seq.Length - 2; i++)
                {
                    string substr = seq.Substring(i, 3);
                    if (pwdLower.Contains(substr))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
