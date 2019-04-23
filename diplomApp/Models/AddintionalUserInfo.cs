using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace diplomApp.Models
{
    public class AddintionalUserInfo
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public long vkId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Education { get; set; }
        public int ResultPercent { get; set; }
        public string PathToAvatar { get; set; }
    }
}