using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace diplomApp.Models
{
    public class User
    {
        [Index(IsUnique = true)]
        public int Id { get; set; }

        public string UserId { get; set; }

        public long vkId { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Display(Name ="Город")]
        public string City { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Образование")]
        public string Education { get; set; }

        [Display(Name = "Результат прохождения курса")]
        public int ResultPercent { get; set; }

        [Display(Name = "Аватар")]
        public string PathToAvatar { get; set; }

        public ICollection<Result> Results { get; set; }

        public User()
        {
            ResultPercent = 0;
            PathToAvatar = "/content/images/default.png";
            Results = new List<Result>();
        }

        
    }

}