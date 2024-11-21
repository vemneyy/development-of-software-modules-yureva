using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab_2_classes
{
    public class Password
    {
        protected string password;

        public Password(string password)
        {
            this.password = password;
        }

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

    public class StrongPassword : Password
    {
        public StrongPassword(string password) : base(password)
        {
        }

        public bool AnalyzePasswordStrength(List<string> personalInfo, DateTime birthDate, out string message)
        {
            string password = this.password;
            List<string> messages = new List<string>();
            bool isStrong = true;

            // 1. Проверка длины пароля
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

            // 4. Проверка на отсутствие личной информации
            foreach (var info in personalInfo)
            {
                if (!string.IsNullOrEmpty(info) && password.ToLower().Contains(info.ToLower()))
                {
                    messages.Add($"Пароль не должен содержать личную информацию: {info}");
                    isStrong = false;
                }
            }

            // 5. Проверка на дату рождения
            if (ContainsBirthDate(password, birthDate))
            {
                messages.Add("Пароль не должен содержать комбинации цифр, связанные с датой рождения.");
                isStrong = false;
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

        private bool ContainsKeyboardSequence(string password)
        {
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

        private bool ContainsBirthDate(string password, DateTime birthDate)
        {
            // Форматы дат для проверки
            string[] dateFormats = new string[]
            {
                birthDate.ToString("ddMMyyyy"), // Формат: 25072006
                birthDate.ToString("MMddyyyy"), // Формат: 07252006
                birthDate.ToString("yyyyMMdd"), // Формат: 20060725
                birthDate.ToString("yyyyddMM"), // Формат: 20062507
                birthDate.ToString("MMdd"),    // Формат: 0725
                birthDate.ToString("ddMM")     // Формат: 2507
            };

            // Проверка каждого формата на наличие в пароле
            foreach (var format in dateFormats)
            {
                if (password.Contains(format))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
