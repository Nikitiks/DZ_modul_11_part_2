using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DZ_modul_11_part_2
{
    class Poem
    {
        //Название стиха;
        public string title { get; set; }
        //            ФИО автора;
        public string name { get; set; }
        //            Год написания;
        public DateOnly date_writing { get; set; }
        //            Текст стиха;
        public string text_poem { get; set; }
        //            Тема стиха.
        public string theme_poem { get; set; }

        public int GetLenght => text_poem.Length;
        public Poem()
        {
            
        }
        public Poem(string title, string name, DateOnly date_writing, string text_poem, string theme_poem)
        {
            this.title = title;
            this.name = name;
            this.date_writing = date_writing;
            this.text_poem = text_poem;
            this.theme_poem = theme_poem;
        }

        public override string ToString()
        {
            return $"Стих '{title}', Автор: {name}, Год написания: {date_writing}\n\t\tТема стиха: {theme_poem}\n\n{text_poem}\n" + new string('-',50) + '\n';
        }
    }

    class Collection_Poem
    {
        public List<Poem> listPoem;

        public Collection_Poem(params Poem[] poems)
        {
            listPoem =new List<Poem> (poems);
        }

        //            Добавлять стихи;
        public void Add(params Poem[] poems)
        {
            foreach(var poem in poems )
            listPoem.Add(poem);

        }
        //            Удалять стихи;
        public void Delete(string title)
        {
            if(listPoem.FirstOrDefault(p => p.title == title) is var poem)
            {
             
            listPoem.Remove(poem);
            return;
                    
            }
            throw new Exception($"Ниодного стиха с названием {title}, не найдено");
        }
        //            Изменять информацию о стихах;
        public void Redact(string title)
        {
            if ( listPoem.FirstOrDefault(p => p.title == title)  is var poem)
            {
                while(true)

                {
                    Console.WriteLine("Выберете какой параметр вы хотите изменить:\r\n1 Название стиха;\r\n2 ФИО автора;\r\n3 Год написания;\r\n4 Текст стиха;\r\n5 Тема стиха.");
                
                    int choise = int.Parse(Console.ReadLine());

                    switch (choise)
                    {
                        case 1:
                            Console.WriteLine("Название стиха");
                            string title_n = Console.ReadLine();
                            poem.title = title_n;
                            Console.WriteLine("Изменение применено");
                            break;

                        case 2:
                            Console.WriteLine("ФИО автора");
                            string name_n = Console.ReadLine();
                            poem.name = name_n;
                            Console.WriteLine("Изменение применено");
                            break;

                        case 3:
                            Console.WriteLine("Дата написания year, month, day");
                            DateOnly year_n = DateOnly.Parse(Console.ReadLine());
                            poem.date_writing = year_n;
                            Console.WriteLine("Изменение применено");
                            break;

                        case 4:
                            Console.WriteLine("Текст стиха");
                            string text_n = Console.ReadLine();
                            poem.text_poem = text_n;
                            Console.WriteLine("Изменение применено");
                            break;

                        case 5:
                            Console.WriteLine("Тема стиха");
                            string theme_n = Console.ReadLine();
                            poem.theme_poem = theme_n;
                            Console.WriteLine("Изменение применено");
                            break;

                        default:
                            Console.WriteLine("Операция завершена");
                            return;
                    }
}
            }
            throw new Exception($"Ниодного стиха с названием {title}, не найдено");
        }
        //            Искать стих по разным характеристикам;
        public Poem Find()
        {
            Poem poem;
                Console.WriteLine("Выберете параметр для поиска:\r\n1 Название стиха;\r\n2 ФИО автора;\r\n3 Год написания;\r\n4 Текст стиха;\r\n5 Тема стиха.");

                int choise = int.Parse(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Название стиха");
                        string title_n = Console.ReadLine();
                    poem= listPoem.FirstOrDefault(p => p.title == title_n);
                        break;

                    case 2:
                        Console.WriteLine("ФИО автора");
                        string name_n = Console.ReadLine();
                    poem = listPoem.FirstOrDefault(p => p.name == name_n);
                    break;

                    case 3:
                        Console.WriteLine("Год написания ");
                        int year_n = int.Parse(Console.ReadLine());
                    poem = listPoem.FirstOrDefault(p => p.date_writing.Year == year_n);
                    break;

                    case 4:
                        Console.WriteLine("Текст стиха");
                        string text_n = Console.ReadLine();
                    poem = listPoem.FirstOrDefault(p => p.text_poem == text_n);
                    break;

                    case 5:
                        Console.WriteLine("Тема стиха");
                        string theme_n = Console.ReadLine();
                    poem = listPoem.FirstOrDefault(p => p.theme_poem == theme_n);
                    break;

                    default:
                        Console.WriteLine("Неверный параметр. Операция завершена");
                        return new Poem();
                }


            if (poem != null)
                return poem;

            throw new Exception($"Ниодного стиха не найдено");
        }

        //            Сохранять коллекцию стихов в файл;
        public void Save()
        {
            if(listPoem == null) throw new Exception($"Список стихов пуст");


                FileLoadSave.file = "Poem.json";
                FileLoadSave.Save(listPoem);
            
        }
        //            Загружать коллекцию стихов из файла.
        public void Load()
        {

            FileLoadSave.file = "Poem.json";
            FileLoadSave.Load(ref listPoem);

        }

        public string LogTitle(string t)
        {
           return LogPoem.LogTitle(listPoem, t);
        }
        public string LogName(string n)
        {
            return LogPoem.LogName(listPoem, n);
        }
        public string LogTheme(string t)
        {
            return LogPoem.LogTheme(listPoem, t);
        }
        public string LogTextWord(string w)
        {
            return LogPoem.LogTextWord(listPoem, w);
        }
        public string LogYear(int y)
        {
            return LogPoem.LogYear(listPoem, y);
        }
        public string LogLenght(int l)
        {
            return LogPoem.LogLenght(listPoem, l);
        }
    }
    class LogPoem
    {
        //            По названию стиха;
       public static string LogTitle(List<Poem> poem, string t)
        {
            var list_log = poem.Where(p => p.title == t).ToList();

            FileLoadSave.file = "LogPoem.json";
            if (list_log != null) 
            {
                string jsonString = "Отчет по названию стиха: "+t;
                jsonString += JsonSerializer.Serialize(list_log, FileLoadSave.Options);
                FileLoadSave.Save(jsonString);
                return jsonString;
            }
            else
                throw new Exception($"Ниодного стиха не найдено");
        }
        //            По ФИО автора;
        public static string LogName(List<Poem> poem, string n)
        {
            var list_log = poem.Where(p => p.name.Split(' ').Last() == n || p.name == n).ToList();

            FileLoadSave.file = "LogPoem.json";
            if (list_log != null) 
            {
                string jsonString = "Отчет по ФИО автора: "+n;
                jsonString += JsonSerializer.Serialize(list_log, FileLoadSave.Options);
                FileLoadSave.Save(jsonString);
                return jsonString;
            }
            else
                throw new Exception($"Ниодного стиха не найдено");
        }
        //            По теме стиха;
        public static string LogTheme(List<Poem> poem, string t)
        {
            var list_log = poem.Where(p => p.theme_poem.ToLower().Contains(t.ToLower())).ToList();

            FileLoadSave.file = "LogPoem.json";
            if (list_log != null)
            {
                string jsonString = "Отчет по теме стиха: " + t;
                jsonString += JsonSerializer.Serialize(list_log, FileLoadSave.Options);
                FileLoadSave.Save(jsonString);
                return jsonString;
            }
            else
                throw new Exception($"Ниодного стиха не найдено");
        }
        //            По слову в тексте стиха;
        public static string LogTextWord(List<Poem> poem, string w)
        {
            var list_log = poem.Where(p => p.theme_poem.ToLower().Contains(w.ToLower())).ToList();

            FileLoadSave.file = "LogPoem.json";
            if (list_log != null)
            {
                string jsonString = "Отчет по слову в тексте стиха: " + w;
                jsonString += JsonSerializer.Serialize(list_log, FileLoadSave.Options);
                FileLoadSave.Save(jsonString);
                return jsonString;
            }
            else
                throw new Exception($"Ниодного стиха не найдено");
        }
        //            По году написания стиха;
        public static string LogYear(List<Poem> poem, int y)
        {
            var list_log = poem.Where(p => p.date_writing.Year == y).ToList();

            FileLoadSave.file = "LogPoem.json";
            if (list_log != null)
            {
                string jsonString = "Отчет по году написания стиха: " + y;
                jsonString += JsonSerializer.Serialize(list_log, FileLoadSave.Options);
                FileLoadSave.Save(jsonString);
                return jsonString;
            }
            else
                throw new Exception($"Ниодного стиха не найдено");
        }
        //            По длине стиха.
        public static string LogLenght(List<Poem> poem, int l)
        {
            int range_min = l;
            int range_max = l + 50;
            var list_log = poem.Where(p => p.GetLenght >= range_min && p.GetLenght <= range_max).ToList();

            FileLoadSave.file = "LogPoem.json";
            if (list_log != null)
            {
                string jsonString = $"Отчет по длине стиха: от {range_min} до {range_max}";
                jsonString += JsonSerializer.Serialize(list_log, FileLoadSave.Options);
                FileLoadSave.Save(jsonString);
                return jsonString;
            }
            else
                throw new Exception($"Ниодного стиха не найдено");
        }
    }
    class FileLoadSave
    {
        public static string file { get; set; }

        public static JsonSerializerOptions Options => new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };
        
        public static void Save(List<Poem> poem)
        {
            
            string jsonString = JsonSerializer.Serialize(poem, Options);
            File.WriteAllText(file, jsonString);
            Console.WriteLine("Данные сохранены");

        }
        public static void Save(string jsonPoem)
        {
            File.WriteAllText(file, jsonPoem);
            Console.WriteLine("Данные сохранены");
        }
        public static void Load(ref List<Poem> poem)
        {
            string fileString = File.ReadAllText(file);
            poem = JsonSerializer.Deserialize< List<Poem>>(fileString);

            if (poem.Count > 0)
                Console.WriteLine("Данные загружены");
            else
                throw new Exception("Ошибка загрузки данных");
        }
    }

    public class Restaurant
    {
        
        public string Nick { get; set; }
        public string Email { get; set; }
        public string UserPhone { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantCuisine { get; set; }
        public string RestaurantPhone { get; set; }
        public string RestaurantRating { get; set; } 
        public string UserReview { get; set; }

        
        public Restaurant() { }

        
        public Restaurant(string nick, string email, string userPhone, string restaurantName,
                          string restaurantAddress, string restaurantCuisine, string restaurantPhone,
                          string restaurantRating, string userReview)
        {
            if (!correctNick(nick))
                throw new ArgumentException("Некорректный ник");
            if (!correctEmail(email))
                throw new ArgumentException("Некорректный email");
            if (!correctUserPhone(userPhone))
                throw new ArgumentException("Некорректный номер пользователя");
            if (!correctRestaurantName(restaurantName))
                throw new ArgumentException("Некорректное название ресторана");
            if (!correctRestaurantAddress(restaurantAddress))
                throw new ArgumentException("Некорректный адрес ресторана");
            if (!correctRestaurantCuisine(restaurantCuisine))
                throw new ArgumentException("Некорректная кухня ресторана");
            if (!correctUserPhone(restaurantPhone))
                throw new ArgumentException("Некорректный телефон ресторана");
            if (!correctRestaurantRating(restaurantRating))
                throw new ArgumentException("Некорректная оценка ресторана");
            if (!correctUserReview(userReview))
                throw new ArgumentException("Некорректный отзыв");

            
            Nick = nick;
            Email = email;
            UserPhone = userPhone;
            RestaurantName = restaurantName;
            RestaurantAddress = restaurantAddress;
            RestaurantCuisine = restaurantCuisine;
            RestaurantPhone = restaurantPhone;
            RestaurantRating = restaurantRating;
            UserReview = userReview;
        }

        private bool correctNick(string nick)
        {

            string mask = @"^[A-Za-zА-Яа-я0-9]+$";
            Regex regex =new Regex(mask);
            if (regex.IsMatch(nick)) return true;

            return false;
        }
        private bool correctEmail(string email)
        {

            string mask = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            Regex regex = new Regex(mask);
            if (regex.IsMatch(email)) return true;

            return false;
        }
        private bool correctRestaurantName(string name)
        {

            string mask = @"^[A-Za-zА-Яа-я ]+$";
            Regex regex = new Regex(mask);
            if (regex.IsMatch(name)) return true;

            return false;
        }
        private bool correctUserPhone(string phone)
        {

            string mask = @"^\d{9}$";
            Regex regex = new Regex(mask);
            if (regex.IsMatch(phone)) return true;

            return false;
        }
        private bool correctRestaurantAddress(string address)
        {

            string mask = @"^[A-Za-zА-Яа-я0-9 ]+$";
            Regex regex = new Regex(mask);
            if (regex.IsMatch(address)) return true;

            return false;
        }
        private bool correctRestaurantCuisine(string cuisine)
        {

            string mask = @"^[A-Za-zА-Яа-я]+$";
            Regex regex = new Regex(mask);
            if (regex.IsMatch(cuisine)) return true;

            return false;
        }
        private bool correctRestaurantRating(string rating)
        {

            string mask = @"^(1[0-2]|[1-9])$";
            Regex regex = new Regex(mask);
            if (regex.IsMatch(rating)) return true;

            return false;
        }
        private bool correctUserReview(string review)
        {

            string mask = @"^[A-Za-zА-Яа-яЁё0-9\s.,!?-]+$";
            Regex regex = new Regex(mask);
            if (regex.IsMatch(review)) return true;

            return false;
        }
        public static explicit operator string(Restaurant r)
        {
            return $"Ник: {r.Nick}\n" +
                   $"Email: {r.Email}\n" +
                   $"Телефон пользователя: {r.UserPhone}\n" +
                   $"Название ресторана: {r.RestaurantName}\n" +
                   $"Адрес: {r.RestaurantAddress}\n" +
                   $"Кухня: {r.RestaurantCuisine}\n" +
                   $"Контактный телефон ресторана: {r.RestaurantPhone}\n" +
                   $"Оценка: {r.RestaurantRating}\n" +
                   $"Отзыв: {r.UserReview}";
        }
    }
}
