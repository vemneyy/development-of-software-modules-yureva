using System;
using System.Text;

namespace lab_2_classes
{
    public class VigenereCipher
    {
        private const string Alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        // Метод для шифрования текста с помощью шифра Виженера
        public static string Encrypt(string text, string key)
        {
            StringBuilder result = new StringBuilder();

            // Приводим текст и ключ к верхнему регистру
            text = text.ToUpper(System.Globalization.CultureInfo.CurrentCulture);
            key = key.ToUpper(System.Globalization.CultureInfo.CurrentCulture);

            int keyIndex = 0;

            foreach (char c in text)
            {
                if (Alphabet.Contains(c))
                {
                    // Индекс буквы в алфавите
                    int letterIndex = Alphabet.IndexOf(c);

                    // Индекс буквы ключа в алфавите
                    int shift = Alphabet.IndexOf(key[keyIndex % key.Length]);

                    // Вычисляем новый индекс с учетом сдвига
                    int cipherIndex = (letterIndex + shift) % Alphabet.Length;

                    // Добавляем зашифрованную букву к результату
                    result.Append(Alphabet[cipherIndex]);

                    keyIndex++;
                }
                else
                {
                    // Если символ не из алфавита, просто добавляем его
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        // Метод для дешифрования текста с помощью шифра Виженера
        public static string Decrypt(string text, string key)
        {
            StringBuilder result = new StringBuilder();

            // Приводим текст и ключ к верхнему регистру
            text = text.ToUpper(System.Globalization.CultureInfo.CurrentCulture);
            key = key.ToUpper(System.Globalization.CultureInfo.CurrentCulture);

            int keyIndex = 0;

            foreach (char c in text)
            {
                if (Alphabet.Contains(c))
                {
                    // Индекс буквы в алфавите
                    int letterIndex = Alphabet.IndexOf(c);

                    // Индекс буквы ключа в алфавите
                    int shift = Alphabet.IndexOf(key[keyIndex % key.Length]);

                    // Вычисляем оригинальный индекс буквы
                    int plainIndex = (letterIndex - shift + Alphabet.Length) % Alphabet.Length;

                    // Добавляем расшифрованную букву к результату
                    result.Append(Alphabet[plainIndex]);

                    keyIndex++;
                }
                else
                {
                    // Если символ не из алфавита, просто добавляем его
                    result.Append(c);
                }
            }
            return result.ToString();
        }
    }
}
