using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroStore.Models
{
    public static class SampleData
    {

        public static void Initialize(ApplicationContext appContext)
        {
            string pathToImages = Path.Combine("wwwroot", "MyImages");
            if (!appContext.Accounts.Any())
            {
                List<Account> accounts = new List<Account>();
                accounts.Add(new Account("USER1", "user1", "-_USER1_-", "user1@mail.ru", Path.Combine(pathToImages, "Ava1.png")));
                accounts.Add(new Account("USER2", "user2", "USER_2", "user2@mail.ru", Path.Combine(pathToImages, "Ava2.png")));
                appContext.Accounts.AddRange(accounts);

                List<Developer> developers = new List<Developer>();
                developers.Add(new Developer("DEV1", "dev1", "-_DEV1_-", "dev1@mail.ru", Path.Combine(pathToImages, "Ava3.png")));
                developers.Add(new Developer("DEV2", "dev2", "DEV_2", "dev2@mail.ru", Path.Combine(pathToImages, "Ava4.png")));
                appContext.Developers.AddRange(developers);

                //Добавить покупки мб

                List<MyApp> apps = new List<MyApp>();
                apps.Add(new MyApp(1, "Пираты", "Увлекательная игра про пиратов", "Экшен", 1230, "", Path.Combine(pathToImages, "PiratePreview.png"), Path.Combine(pathToImages, "Pirate.png")));
                apps.Add(new MyApp(1, "MathTime", "Решение примеров за время", "Математика", 1500, "", Path.Combine(pathToImages, "MathTimePreview.png"), Path.Combine(pathToImages, "MathTime.png")));
                apps.Add(new MyApp(2, "Лабиринт", "Пройди лабиринт до конца. Только 1% справляется с этим", "Экшен", 754, "", Path.Combine(pathToImages, "LabirintPreview.png"), Path.Combine(pathToImages, "Labirint.png")));
                appContext.Apps.AddRange(apps);

                List<DLC> dLCs = new List<DLC>();
                dLCs.Add(new DLC(1, "Выключение рекламы", 150));
                dLCs.Add(new DLC(1, "Дополнительные попытки", 350));
                dLCs.Add(new DLC(1, "Новый уровень", 200));
                dLCs.Add(new DLC(2, "(Какое-то DLC)", 100));
                appContext.DLCs.AddRange(dLCs);

                List<Comment> comments = new List<Comment>();
                comments.Add(new Comment(1, 1, "Хорошая игра !", -1, false, "01.05.2021"));
                comments.Add(new Comment(1, 2, "Отличная игра", -1, false, "01.05.2021"));
                comments.Add(new Comment(1, 1, "Спасибо за ваш отзыв", 1, true, "01.05.2021"));
                appContext.Comments.AddRange(comments);

                appContext.SaveChanges();
            }
        }

    }
}