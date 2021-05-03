using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroStore.Models
{
    public static class SampleData
    {

        public static void Initialize(ApplicationContext appContext)
        {
            if (!appContext.Accounts.Any())
            {
                List<Account> accounts = new List<Account>();
                accounts.Add(new Account("USER1", "user1", "-_USER1_-", "user1@mail.ru", "Ava1.png"));
                accounts.Add(new Account("USER2", "user2", "USER_2", "user2@mail.ru", "Ava2.png"));
                appContext.Accounts.AddRange(accounts);

                List<Developer> developers = new List<Developer>();
                developers.Add(new Developer("DEV1", "dev1", "-_DEV1_-", "dev1@mail.ru", "Ava3.png"));
                developers.Add(new Developer("DEV2", "dev2", "DEV_2", "dev2@mail.ru", "Ava4.png"));
                appContext.Developers.AddRange(developers);

                //Добавить покупки мб

                List<App> apps = new List<App>();
                apps.Add(new App(1, "Пираты", "Увлекательная игра про пиратов", "Экшен", 1230, "", "PiratePreview.png", "Pirate.png"));
                apps.Add(new App(1, "MathTime", "Решение примеров за время", "Математика", 1500, "", "MathTimePreview.png", "MathTime.png"));
                apps.Add(new App(2, "Лабиринт", "Пройди лабиринт до конца. Только 1% справляется с этим", "Экшен", 754, "", "LabirintPreview.png", "Labirint.png"));
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