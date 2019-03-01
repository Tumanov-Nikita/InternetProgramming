using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WeBudget.Service.Abstract;

namespace WeBudget.Models
{
    [Serializable]
    public class Notice : BaseEntity
    {
        [Required(ErrorMessage = "Введите заголовок объявления")]
        [RegularExpression(@"^.{1,30}$",
          ErrorMessage = "Введите заголовок объявления")]
        public string name { get; set; }

        public string picFileName { get; set; }

        [Required(ErrorMessage = "Введите цену")]
        [RegularExpression(@"^\d{1,10}",
           ErrorMessage = "Неверно введена цена")]
        public int price { get; set; }

        [Required(ErrorMessage = "Введите текст объявления")]
        [RegularExpression(@"^.{1,255}$", 
           ErrorMessage = "Введите от 1 до 255 символов")]
        public string text { get; set; }

        public int UserId { get; set; }
    }
}