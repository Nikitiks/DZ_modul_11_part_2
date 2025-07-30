using System;
using System.Text.RegularExpressions;

namespace DZ_modul_11_part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            Задание 1
            //Создайте приложение для работы с коллекцией стихов.Необходимо хранить такую информацию:

            //Название стиха;
            //            ФИО автора;
            //            Год написания;
            //            Текст стиха;
            //            Тема стиха.
            //Приложение должно позволять:

            //            Добавлять стихи;
            //            Удалять стихи;
            //            Изменять информацию о стихах;
            //            Искать стих по разным характеристикам;
            //            Сохранять коллекцию стихов в файл;
            //            Загружать коллекцию стихов из файла.
            //Приложение должно иметь возможность генерировать отчёты. Отчёт может быть отображён на экран или сохранён в файл. Создайте такие отчёты:

            //            По названию стиха;
            //            По ФИО автора;
            //            По теме стиха;
            //            По слову в тексте стиха;
            //            По году написания стиха;
            //            По длине стиха.

            //Collection_Poem poems = new Collection_Poem
            //    (new Poem[] {
            //        new Poem("Мгновение", "Сергей Есенин", new DateOnly(1923, 5, 1), "Легкое дуновение ветра...", "Природа"),
            //        new Poem("Ночь", "Анна Ахматова", new DateOnly(1912, 3, 10), "Ночь. Улица. Фонарь. Аптека...", "Философия"),
            //        new Poem("Письмо", "Марина Цветаева", new DateOnly(1921, 11, 5), "Ты — как отзвук мечты...", "Любовь"),
            //        new Poem("Весна", "Федор Тютчев", new DateOnly(1845, 4, 3), "Весна, весна! Как воздух чист!", "Природа")
            //    });

            //poems.Save();
            //Collection_Poem poems1 = new Collection_Poem();
            //poems1.Load();

            //foreach (var p in poems1.listPoem)
            //{
            //    Console.WriteLine(p);
            //}
            //Console.WriteLine(poems1.LogTheme("Природа"));


            //            Задание 2
            //Разработайте приложение для поиска файлов по маске.Пользователь вводит путь к папке и маску для поиска.Например:

            //D:\DataForUser
            //*.txt

            //Приложение должно отобразить все файлы с расширением txt по пути D:\DataForUser.Поиск должен происходить в папках и подпапках.

            //string _path = @"D:\DataForUser";
            //string mask = "*.txt";

            //if(Directory.Exists(_path))
            //{
            //    var files1 = Directory.EnumerateFiles(_path, mask, SearchOption.AllDirectories);
            //    Console.WriteLine($"Все файлы с маской: ({mask}), в директории по пути: {_path}");
            //    foreach (var file in files1)
            //    {
            //        string[] Name = file.Split(@"\");
            //        int l = Name.Length - 1;
            //        Console.WriteLine(Name[l]);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Directory nonconnect");
            //}
            ////Задание 3
            ////Разработайте приложение для удаления файлов по маске.Пользователь вводит путь к папке и маску для поиска удаляемых файлов.Например:

            ////D:\DataForUser
            ////*.txt

            ////Приложение должно удалить все файлы с расширением txt по пути D:\DataForUser.

            ////Файлы должны удаляться в папках и подпапках.Также должны удаляться подпапки в папках.

            //if (Directory.Exists(_path))
            //{
            //    var files1 = Directory.EnumerateFiles(_path, mask, SearchOption.AllDirectories);
                
            //    foreach (var file in files1)
            //    {
            //        File.Delete(file);

            //    }
            //    Console.WriteLine($"Все файлы с маской: ({mask}), в директории по пути: {_path}. Были удалены");
            //}
            //else
            //{
            //    Console.WriteLine("Directory nonconnect");
            //}

            //Задание 4
            //Пользователь вводит с клавиатуры название ресторана.

            //Напишите регулярное выражение для проверки названия ресторана.В названии не может быть символов %, &, ), (.

            string mask2 = @"^[^%&)(]+$";
            Regex regex = new Regex(mask2);
            MatchCollection match;
            string[] rest = { "Дом%еды", "Бургер&Кинг", "Итальянская (Кухня)", "Лучший)ресторан", "Ресторан Лилия", "Pizza House", "Добро Пожаловать!" };
            Console.WriteLine();
            Console.WriteLine("Регулярное выражение для проверки названия ресторана.В названии не может быть символов %, &, ), (");
            foreach (var r in rest)
            {    
                match = regex.Matches(r);
                foreach (var it in match)
                {
                    Console.Write($"\"{it}\" ");
                }
            }
            Console.WriteLine();

            //Задание 5
            //Пользователь вводит с клавиатуры адрес ресторана.

            //Напишите регулярное выражение для проверки адреса ресторана.В названии могут быть только буквы английского алфавита и цифры.

            string mask_address = @"^[A-Za-z0-9]+$";
            Regex regex_address = new Regex(mask_address);
            MatchCollection match_address;
            string[] rest_address = { "MainStreet123", "WallSt45", "Highway9", "PizzaHut22", "Main Street 123", "Main-Street", "12Street", "улица45" };
            Console.WriteLine();
            Console.WriteLine("Регулярное выражение для проверки адреса ресторана.В названии могут быть только буквы английского алфавита и цифры.");
            foreach (var r in rest_address)
            {
                match_address = regex_address.Matches(r);
                foreach (var it in match_address)
                {
                    Console.Write($"\"{it}\" ");
                }
            }
            Console.WriteLine();

            //Задание 6
            //Пользователь вводит с клавиатуры название кухни ресторана.

            //Напишите регулярное выражение для проверки названия кухни ресторана. В названии могут быть только буквы английского алфавита в любом регистре.Пример названия кухни: italian, ukrainian, georgian, jewish и т.д.

            string mask_cuisine = @"^[A-Za-z]+$";
            Regex regex_cuisine = new Regex(mask_cuisine);
            MatchCollection match_cuisine;
            string[] rest_cuisine = { "italian" , "ukrainian", "georgian", "jewish","Японская","Китайская","Тайская" };
            Console.WriteLine();
            Console.WriteLine("Регулярное выражение для проверки названия кухни ресторана. В названии могут быть только буквы английского алфавита в любом регистре.");
            foreach (var r in rest_cuisine)
            {
                match_cuisine = regex_cuisine.Matches(r);
                foreach (var it in match_cuisine)
                {
                    Console.Write($"\"{it}\" ");
                }
            }
            Console.WriteLine();

            //Задание 7
            //Пользователь вводит с клавиатуры оценку работы ресторана.Напишите регулярное выражение для проверки оценки. Оценка может варьироваться от 1 до 12.

            string mask_ball = @"^(1[0-2]|[1-9])$";
            Regex regex_ball = new Regex(mask_ball);
            MatchCollection match_ball;
            string[] rest_ball = { "2", "5", "9", "100", "23", "12", "-1", "-60" };
            Console.WriteLine();
            Console.WriteLine("Регулярное выражение для проверки оценки. Оценка может варьироваться от 1 до 12.");
            foreach (var r in rest_ball)
            {
                match_ball = regex_ball.Matches(r);
                foreach (var it in match_ball)
                {
                    Console.Write($"\"{it}\" ");
                }
            }
            Console.WriteLine();
            //Задание 8
            //Разработайте приложение для оценки деятельности ресторана. Пользователь вводит с клавиатуры такую информацию:

            //Ник;
            //            Электронный адрес;
            //            Номер телефона;
            //            Название ресторана;
            //            Адрес ресторана;
            //            Кухня ресторана;
            //            Контактный номер телефона ресторана;
            //            Оценка ресторана;
            //            Отзыв пользователя о ресторане.
            //Используя регулярные выражения проверьте данные, введенные в форму.Если пользователь где - то совершил ошибку при вводе, сообщите ему об этом.Если информация была введена успешно, сохраните информацию в файл.
            try
            {
                Restaurant goodRestaurant = new Restaurant(
                    nick: "Никита",
                    email: "nikita@example.com",
                    userPhone: "123456789",
                    restaurantName: "Pizza House",
                    restaurantAddress: "Главная 1",
                    restaurantCuisine: "Итальянская",
                    restaurantPhone: "987654321",
                    restaurantRating: "10",
                    userReview: "Очень вкусная пицца и приятный сервис!"
                );

                Console.WriteLine("Ресторан создан успешно:");
                Console.WriteLine($"Название: {goodRestaurant.RestaurantName}");
                Console.WriteLine($"Оценка: {goodRestaurant.RestaurantRating}");
                Console.WriteLine($"Отзыв: {goodRestaurant.UserReview}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании ресторана: {ex.Message}");
            }

            try
            {
                // Попытка создать ресторан с некорректным рейтингом
                Restaurant badRestaurant = new Restaurant(
                    nick: "Иван",
                    email: "ivan@example.com",
                    userPhone: "123456789",
                    restaurantName: "Bad Restaurant",
                    restaurantAddress: "Плохая 2",
                    restaurantCuisine: "Фастфуд",
                    restaurantPhone: "987654321",
                    restaurantRating: "15",  // некорректный рейтинг!
                    userReview: "Не понравилось"
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ожидаемая ошибка: {ex.Message}");
            }
        }
    }
}
