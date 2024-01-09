// Практическая работа №2
// Написать программу, находящую в массиве две неубывающие последовательности максимальной длины
// Студент группы 414, Кондиляброва Вероника Данииловна. 2023 год
using System;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

public class array
{
    static int Input_positive_int()
    {
        bool inputSuccess = false;
        int input = 0;
        while (!inputSuccess)
        {
            string consoleInput = Console.ReadLine();
            if (!int.TryParse(consoleInput, out input))
            {
                Console.WriteLine(
                "Значение должно быть числом.");
                continue;
            }
            inputSuccess = true;
        }
        return input;
    }

    static double Input_positive()
    {
        bool inputSuccess = false;
        double input = 0;
        while (!inputSuccess)
        {
            string consoleInput = Console.ReadLine();
            if (!double.TryParse(consoleInput, out input))
            {
                Console.WriteLine(
                "Значение должно быть числом.");
                continue;
            }
            inputSuccess = true;
        }
        return input;
    }
    static int Input_choice()
    {
        bool inputSuccess = false;
        int input = 0;
        while (!inputSuccess)
        {
            string consoleInput = Console.ReadLine();
            if (!int.TryParse(consoleInput, out input))
            {
                Console.WriteLine(
                "Значение должно быть числом.");
                continue;
            }
            if (input > 2 || input < 1)
            {
                Console.WriteLine(
                "Попробуйте еще раз:");
                continue;
            }
            inputSuccess = true;
        }
        return input;
    }
    static int Input_size()
    {
        bool inputSuccess = false;
        int input = 0;
        while (!inputSuccess)
        {
            string consoleInput = Console.ReadLine();
            if (!int.TryParse(consoleInput, out input))
            {
                Console.WriteLine(
                "Значение должно быть числом.");
                continue;
            }
            if (input < 1)
            {
                Console.WriteLine(
"Значение должно быть положительным и больше 0.");
                continue;
            }
            inputSuccess = true;
        }
        return input;
    }

    public static void Main()
    {
        Console.WriteLine("Кондиляброва Вероника\n414 группа\nВариант 8\nПрактическая работа 2\nНаписать программу, находящую в массиве две неубывающие последовательности максимальной длины.");
        int size = 0;
        List<double> numbers = new List<double>();

        int end = 0;
        while (end != 1)
        {
            Console.WriteLine("Ввести данные вручную - 1, считать данные из файла - 2, получить две максимальные длины - 3, выйти из программы - 4: ");

            int user_choice = Input_positive_int();
            

            switch (user_choice)
            {
                case (int)Menu.Manual_Input:
                    {
                        Console.Write("Введите размер массива: ");
                        size = Input_size();
                        if (numbers.Count() != 0)
                        {
                            numbers.Clear();
                        }
                        for (int i=0; i<size; i++)
                        {
                            Console.Write("[");
                            Console.Write(i+1);
                            Console.Write("]: ");

                            numbers.Add(Input_positive());
                        }
                        Save_initial_data(numbers);

                    }
                    break;
                case (int)Menu.File_Input:
                    {
                        Console.Write("Введите название файла: ");
                        //string s;
                        string path = Console.ReadLine();
                        StreamReader f = new StreamReader(path);

                        while (!f.EndOfStream)
                        {
                            string s = f.ReadLine();
                            numbers.Add(double.Parse(s));
                        }
                        f.Close();
                        if (numbers.Count() != 0)
                        {
                            Console.WriteLine("Сохранено.");
                        }
                        else
                        {
                            Console.WriteLine("Файл пустой.");
                        }
                    }
                    break;
                case (int)Menu.Get_result:
                    {
                        if (numbers.Count()==0)
                        {
                            Console.WriteLine("Сначала введите данные.");
                            break;
                        }
                        //if (get_result == false)
                        //{
                        //    Console.WriteLine("Файл заполнен неверно.");
                        //    break;
                        //}

                        if (Find_max(numbers).Count != 0)
                        {
                            Console.WriteLine("Результат:");
                            for (int i = 0; i < Find_max(numbers).Count; i += 2)
                            {
                                Console.Write(Find_max(numbers)[i]);
                                Console.Write("\t По индексу:");
                                Console.WriteLine(Find_max(numbers)[i + 1]);
                            }
                            Save_f(Find_max(numbers));
                            numbers.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Максимальных длин не найдено.");
                            numbers.Clear();
                        }
                    }
                        break;
                case (int)Menu.Exit:
                    {
                        end = 1;
                    }
                    break;
                default:
                    Console.WriteLine(
                    "Попробуйте еще раз.");
                    break;
            }
        }
    }

    static void Save_initial_data(List<double> numb)
    {
        bool check = true;
        Console.WriteLine("Сохранить в файл? Да - 1, Нет - 2");
        int choice_save = Input_choice();
        if (choice_save == 1)
        {
            do
            {
                
                FileStream fs;
                StreamWriter sw;
                string initial_data = "";
                Console.WriteLine("Добавить в существующий файл или создать новый - 1, Перезаписать существующий файл - 2");
                choice_save = Input_choice();
                if (choice_save == 1)
                {
                    Console.Write("Введите название файла: ");
                    string path = Console.ReadLine();
                    if (path == "con.txt")
                    {
                        Console.WriteLine("Данное название не подходит.");
                        check = false;
                        continue;
                    }
                    for (int i = 0; i < numb.Count(); i++)
                    {
                        initial_data += numb[i].ToString() + "\n";
                    }
                    // добавление в файл
                    try
                    {
                        // FileStream
                        fs = new FileStream(path, FileMode.Append);
                        sw = new StreamWriter(fs);

                        

                        using (sw)
                        {
                            sw.Write(initial_data);
                        }
                        Console.WriteLine("Сохранено");
                        check = true;
                    }
                    catch (System.ArgumentException)
                    {
                        Console.WriteLine("Данное название не подходит.");
                        check = false;
                        continue;
                    }                 
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("Данное название не подходит.");
                        check = false;
                        continue;
                    }
                }
                if(choice_save == 2)
                {
                    Console.Write("Введите название файла: ");
                    string path = Console.ReadLine();
                    if (path == "con.txt")
                    {
                        Console.WriteLine("Данное название не подходит.");
                        check = false;
                        continue;
                    }
                    for (int i = 0; i < numb.Count(); i++)
                    {
                        initial_data += numb[i].ToString() + "\n";
                    }
                    // полная перезапись файла 
                    try
                    {
                        // FileStream
                        fs = new FileStream(path, FileMode.Truncate);
                        sw = new StreamWriter(fs);
                        using (sw)
                        {
                            sw.Write(initial_data);
                        }
                        Console.WriteLine("Сохранено");
                        check = true;
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("Данное название не подходит.");
                        check = false;
                        continue;
                    }
                }
            } while (check == false);
        }
    }
    static void Save_f(List<int> max)
    {
        bool check= true;
        FileStream fs;
        StreamWriter sw;
        Console.WriteLine("Сохранить в файл? Да - 1, Нет - 2");
        int choice_save = Input_choice();
            if (choice_save == 1)
            {
            do { 
                string array_max = "";
                Console.WriteLine("Добавить в существующий файл или создать новый - 1, Перезаписать существующий файл - 2");
                choice_save = Input_choice();
                if (choice_save == 1)
                {
                    Console.Write("Введите название файла: ");
                    string path = Console.ReadLine();
                    if (path == "con.txt")
                    {
                        Console.WriteLine("Данное название не подходит.");
                        check = false;
                        continue;
                    }
                    for (int i = 0; i < max.Count(); i += 2)
                    {
                        array_max += max[i].ToString() + "\t По индексу:" + max[i + 1].ToString() + "\n";
                    }

                    // добавление в файл
                    try
                    {
                        // FileStream
                        fs = new FileStream(path, FileMode.Append);
                        sw = new StreamWriter(fs);
                        using (sw)
                        {
                            sw.Write(array_max);
                        }
                        Console.WriteLine("Сохранено");
                        check = true;
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Данное название не подходит.");
                        check = false;
                        continue;
                    }
                }
                else
                {
                    Console.Write("Введите название файла: ");
                    string path = Console.ReadLine();
                    if (path == "con.txt")
                    {
                        Console.WriteLine("Данное название не подходит.");
                        check = false;
                        continue;
                    }
                    for (int i = 0; i < max.Count(); i += 2)
                    {
                        array_max += max[i].ToString() + "\t По индексу:" + max[i + 1].ToString() + "\n";
                    }
                    // полная перезапись файла 
                    try
                    {
                        // FileStream
                        fs = new FileStream(path, FileMode.Truncate);
                        sw = new StreamWriter(fs);
                        using (sw)
                        {
                            sw.Write(array_max);
                        }
                        Console.WriteLine("Сохранено");
                        check = true;
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Данное название не подходит.");
                        check = false;
                        continue;
                    }
                }
            } while (check == false);
        } 
    }


    static public List<int> Find_max(List<double> numb)
    {
        bool count = true;
        int k = 0;
        List<int> count_numbers = new List<int>();
        List<int> index = new List<int>();
        List<int> result = new List<int>();
        for (int i=0; i<(numb.Count-1); i++)
        {
            if (numb[i + 1] > numb[i])
            {
                k++;
                if (i == numb.Count - 2)
                {
                    count_numbers.Add(k);
                    index.Add(i - k + 2);
                }
            }
            else
            {
                if (k != 0)
                {
                    count_numbers.Add(k);
                    index.Add(i - k + 1);
                    k = 0;
                }
            }


        }

        int max1 = 0;
        int max2 = 0;

        int size_count_numbers = count_numbers.Count();

        if (size_count_numbers > 1)
        {
            max1 = count_numbers.Max();
            int index_max=count_numbers.IndexOf(max1);
            count_numbers.Remove(count_numbers.Find(p => p == max1));
            max2 = count_numbers.Max();
            result.Add(max1+1);
            result.Add(index[index_max]);
            index.Remove(index[index_max]);
            index_max = count_numbers.IndexOf(max2);
            result.Add(max2 + 1);
            result.Add(index[index_max]);
            
        }
        if (size_count_numbers == 1)
        {
            max1 = count_numbers.Max();
            result.Add(max1 + 1);
            result.Add(index[0]);
        }
        return result;
    }

    enum Menu : int
    {
        Manual_Input = 1,
        File_Input,
        Get_result,
        Exit
    }
}
