using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelingTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //путь к файлу для чтения карточек
            string readPath = @"C:\Users\Тернт\Documents\Visual Studio 2015\Projects\TravelingTask\1.txt";

            //вызываем метод Travel и передаем ему путь к файлу для чтения
            Travel travel = new Travel(readPath);
        }

        public class Travel
        {
            //переменная для хранения пропущенного через алгоритм текста
            public string text = "";

            //время выполнения программы
            public double time;

            public Travel(string readPath)
            {
                System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();

                //запускает измерение затраченного времени
                swatch.Start();

                //словарь, содержащий неотсортированные карточки
                Dictionary<string, string> notOrderedCardsTxt = new Dictionary<string, string>();

                //словарь, содержащий отсортированные карточки
                Dictionary<string, string> orderedCardsTxt = new Dictionary<string, string>();

                //путь к файлу для записи отсортированных карточек
                string writePath = @"C:\Users\Тернт\Documents\Visual Studio 2015\Projects\TravelingTask\2.txt";

                try
                {
                    FileStream file1 = new FileStream(readPath, FileMode.Open);
                    FileStream file2 = new FileStream(writePath, FileMode.Open);

                    StreamReader reader = new StreamReader(file1, Encoding.Default);
                    StreamWriter writer = new StreamWriter(file2, Encoding.Default);

                    string str = "";

                    while ((str = reader.ReadLine()) != null)
                    {
                        //запись карточек в словарь неотсортированных карточек, где ключом будет являться пункт отправления, а значением - пункт назначения.
                        notOrderedCardsTxt.Add(str.Split(' ')[0], str.Split(' ')[1]);
                    }

                    //запись в отсортированный словарь первой пары пункт отправления - пункт назначения, 
                    //которую нужно еще найти по правилу, что пункт назначения больше не встречается в карточках
                    foreach (var el in notOrderedCardsTxt)
                    {
                        if (!notOrderedCardsTxt.Values.Select(cart => cart).Contains(el.Key))
                        {
                            orderedCardsTxt.Add(el.Key, el.Value);
                            break;
                        }
                    }

                    //алгоритм сортировки
                    for (int j = 0; j < notOrderedCardsTxt.Count; j++)
                    {
                        //запись в переменную val последнегего полученного пункта назначения после сортировки
                        string val = orderedCardsTxt.Values.Last();

                        //организовываем поиск по всем ключам неотсортированного словаря пункта назначения, 
                        //который совпадал бы с последним пунктом назначения, уже отсортированным
                        foreach (var key in notOrderedCardsTxt.Keys)
                        {
                            if (val == key)
                            {
                                //записываем в отсортированный словарь ключ - совпавший пункт назначения и соответствующее ему значение из неотсортированного словаря
                                orderedCardsTxt.Add(key, notOrderedCardsTxt[key]);
                                break;
                            }
                        }
                    }

                    //записываем в переменную text построчно отсортированные карточки
                    foreach (var el in orderedCardsTxt)
                    {
                        text = text + el.Key + " " + orderedCardsTxt[el.Key] + "\r\n";
                    }

                    //очищаем text от последнего переноса строки и возврата каретки
                    text = text.Substring(0, text.Length - 2);

                    //записываем в файл txt построчно отсортированные карточки
                    foreach (var el in text.Split('\n'))
                    {
                        writer.WriteLine(el);
                    }

                    writer.Close();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                //останавливаем измерение затраченного времени
                swatch.Stop();

                //получаем значение в миллисекундах, затраченное на работу кода
                time = swatch.Elapsed.TotalMilliseconds;
            }
        }
    }
}
