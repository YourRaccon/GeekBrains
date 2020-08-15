using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DZ2
{
    //Корбун Т.И.
    /*
     Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
     а) Вывести только те слова сообщения,  которые содержат не более n букв.
     б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
     в) Найти самое длинное слово сообщения.
     г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
     д) ***Создать метод, который производит частотный анализ текста. 
     В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает 
     сколько раз каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary.
     */

    //Для тестирования можете использовать к примеру: "dogy dogZZ dogzy dog and catzy catZ cat dog"
    static class Message
    {
        public static void PrintWordsInMessage(string message, int n)
        {
            string regular = @"\b\w{1," + n + @"}\b";
            Regex regex = new Regex(regular);
            MatchCollection matches = regex.Matches(message);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }

        public static void DeleteWordsWithLastSymbol(string message, char symbol)
        {
            string result = message;
            string regular = @"\b\w*" + symbol + @"\b";
            Regex regex = new Regex(regular);
            MatchCollection matches = regex.Matches(message);
            foreach (Match match in matches)
            {
                result = result.Replace(match.Value, "");
            }
            Console.WriteLine(result);
        }

        public static void FindLongestWord(string message)
        {
            int max = 0;
            StringBuilder result = new StringBuilder();
            string regular = @"\b\w+\b";
            Regex regex = new Regex(regular);
            MatchCollection matches = regex.Matches(message);
            foreach (Match match in matches)
            {
                int length = match.Value.Length;
                if (length > max)
                {
                    result.Clear();
                    result.Append(match.Value);
                    max = length;
                }
                else if (length == max)
                {
                    result.Append(", " + match.Value);
                }
            }
            Console.WriteLine(result);
        }

        //Вариант для задания
        public static Dictionary<string, int> CountWords(string[] words, string message)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach(string word in words)
            {
                string regular = @"\b" + word + @"\b";
                Regex regex = new Regex(regular);
                dictionary.Add(word, regex.Matches(message).Count);
            }
            return dictionary;
        }

        //Вариант для тестирования
        public static Dictionary<string, int> CountWords(string message)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            string regular = @"\b\w+\b";
            Regex regex = new Regex(regular);
            MatchCollection matches = regex.Matches(message);
            foreach (Match match in matches)
            {
                string word = match.Value;
                if (!dictionary.ContainsKey(word))
                {
                    string wordRegular = @"\b" + word + @"\b";
                    Regex wordRegex = new Regex(wordRegular);
                    dictionary.Add(match.Value, wordRegex.Matches(message).Count);
                }
            }
            return dictionary;
        }

        public static void PrintWordsCount(Dictionary<string, int> dictionary)
        {
            foreach(KeyValuePair<string, int> pair in dictionary)
            {
                Console.WriteLine("Слово {0} встретилось {1} раз/а", pair.Key, pair.Value);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите текст: ");
            string message = Console.ReadLine();

            Console.WriteLine("Слова, чья длина меньше или равна 3: ");
            Message.PrintWordsInMessage(message, 3);

            Console.Write("Удалены слова, которые заканчиваются на Z: ");
            Message.DeleteWordsWithLastSymbol(message, 'Z');

            Console.Write("Самое длинное слово в тексте: ");
            Message.FindLongestWord(message);

            Console.WriteLine("Частота слов в тексте: ");
            Dictionary<string, int> dictionary = Message.CountWords(message);
            Message.PrintWordsCount(dictionary);

            Console.ReadKey();
        }
    }
}
