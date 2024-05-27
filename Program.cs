using System;
using System.IO;

namespace AK_CS
{
    class Program
    {
        public static int Count_Files(string directoryPath, string choice)
        {
            try
            {
                string[] files;

                switch (choice)
                {
                    case "1":
                        
                        files = Directory.GetFiles(directoryPath);
                        return files.Length;

                    case "2":
                        
                        files = Directory.GetFiles(directoryPath, "*.exe");
                        return files.Length;

                    default:
                        Console.WriteLine("Неправильний вибiр. Будь ласка, оберiть 1 або 2.");
                        return 0;
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Помилка: {ex.Message}");
                return -1;
            }
        }

        static void Main()
        {
            Console.WriteLine(@"Якщо вам потрiбна пiдказка, введiть /help, якщо вона не потрiбна, введiть пустий рядок, просто натиснувши ENTER");
            string Is_Help_Needed = Console.ReadLine();
            switch (Is_Help_Needed)
            {
                case "/help":
                    Console.WriteLine("Пiдказка: скрипт пiдраховує кiлькiсть файлiв в заданому каталозi, передавайте довiльну кiлькiсть параметрiв, шляхи до каталогiв (через кому), в яких треба рахувати файли");
                    break;
                case "":
                    break;
                default:
                    Console.WriteLine("Ви не ввели нiчого, що було зазначено вище, тому пiдказка виводиться автоматично:");
                    Console.WriteLine("Пiдказка: скрипт пiдраховує кількiсть файлiв в заданому каталозi, передавайте довiльну кiлькiсть параметрiв, шляхи до каталогiв (через кому), в яких треба рахувати файли");
                    break;

            }
            
            Console.WriteLine("Вкажiть шляхи до каталогiв, роздiленi комами:");
            string input = Console.ReadLine();
            string[] directoryPaths = input.Split(',');

            
            Console.WriteLine("Оберiть опцiю:");
            Console.WriteLine("1 - Пiдрахувати всi файли");
            Console.WriteLine("2 - Пiдрахувати тiльки файли з розширенням .exe");

            string choice = Console.ReadLine();

            foreach (string directoryPath in directoryPaths)
            {
                string trimmedPath = directoryPath.Trim();
                int fileCount = Count_Files(trimmedPath, choice);

                
                if (fileCount == -1)
                {
                    Console.WriteLine($"Помилка пiд час обробки каталогу: {trimmedPath}");
                }
                else
                {
                    Console.WriteLine($"Кiлькiсть файлiв у каталозi '{trimmedPath}': {fileCount}");
                }
            }
        }
    }
}
