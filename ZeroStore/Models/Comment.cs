using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroStore.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AppId { get; set; }
        /// <summary>
        /// Id автора комментария
        /// </summary>
        public int UserId { get; set; }
        public string Text { get; set; }
        /// <summary>
        /// Id комментария, на который ответили. -1 если это не ответ
        /// </summary>
        public int AnsweredTo { get; set; }
        /// <summary>
        /// true - если это комментарий разработчика
        /// </summary>
        public bool IsDeveloper { get; set; }
        public string Date { get; set; }

        public Comment(int appId, int userId, string text, int answeredTo, bool isDeveloper, string date)
        {
            AppId = appId;
            UserId = userId;
            Text = text;
            AnsweredTo = answeredTo;
            IsDeveloper = isDeveloper;
            Date = date;
        }

    }
}
