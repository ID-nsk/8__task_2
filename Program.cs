using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _8__task_2
{
    internal class Program
    {
        static void numbersFile(string direct, string name, string nameFile)
        {
            if (File.Exists($"{direct}\\{nameFile}"))
            {
                Console.WriteLine("Файл с таким именем уже существует. Вы хотите заменить его содержимое?");
                Console.WriteLine("Нажмите 'y' если Вы хотете заменить содержимое файла, 'n' - если нет");
                string answear = Console.ReadLine();
                if (answear == "y" | answear == "н")
                {
                    StreamWriter numbers = File.CreateText($"{direct}\\{nameFile}"); //Здесь мы создали поток sw, а при помощи метода File.CreateText создали файл 
                    {
                        Random rnd = new Random();
                        for (int i = 0; i < 10; i++)
                        {
                            numbers.WriteLine(rnd.Next(100)); //Записываем случайные числа в наш файл
                        }
                    }
                    numbers.Close(); //Закрываем поток
                }
                if (answear == "n" | answear == "т") //Создаём новый файл
                {
                    string newNameFile = nameFile;
                    int n = 1;
                    while (File.Exists($"{direct}\\{newNameFile}"))
                    {
                       newNameFile = name + n.ToString() + ".txt";
                        ++n;
                        nameFile = newNameFile;
                    }
                    StreamWriter numbers = File.CreateText($"{direct}\\{newNameFile}"); 
                    {
                        Random rnd = new Random();
                        for (int i = 0; i < 10; i++)
                        {
                            numbers.WriteLine(rnd.Next(100)); //Записываем случайные числа в наш файл
                        }
                    }
                    numbers.Close(); //Закрываем поток
                }
            }
            else
            {
                StreamWriter numbers = File.CreateText($"{direct}\\{nameFile}"); //Здесь мы создали поток sw, при помощи метода File.CreateText создали файл 
                {
                    Random rnd = new Random();
                    for (int i = 0; i < 10; i++)
                    {
                        numbers.WriteLine(rnd.Next(100)); //Записываем случайные числа в наш файл
                    }
                }
                numbers.Close(); //Закрываем поток
            }
        } 
               static void Main(string[] args)
        {
            Console.Write("Укажите путь директории в которой необходимо созадть файл:");
            string direct = Console.ReadLine();
            Console.WriteLine("Придумайте имя файла:");
            string name = Console.ReadLine();
            string nameFile = name + ".txt";
            numbersFile(direct, name, nameFile);
            Console.WriteLine("Укажите имя созданного файла в котором необходимо подсчитать сумму чисел");
            string[] strNumbers = File.ReadAllLines($"{direct}\\{Console.ReadLine()+".txt"}");
            int count = 0;
            foreach (string strNumber in strNumbers)
            {
                if (Int32.TryParse(strNumber, out int number))
                {
                    count = count + number;
                }
            }

            Console.WriteLine("Сумма чисел: " + count);
            Console.ReadKey();  
        }
    }
}
