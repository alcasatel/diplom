using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace diplomApp.Models
{
    public class AddintionalUserInfo
    {
        public AddintionalUserInfo()
        {
            ResultPercent = 0;
            PathToAvatar = "/content/images/default.png";
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public long vkId { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Display(Name = "Дата рождения")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Образование")]
        public string Education { get; set; }

        [Display(Name = "Результат прохождения курса")]
        public int ResultPercent { get; set; }

        public string PathToAvatar { get; set; }
    }
}