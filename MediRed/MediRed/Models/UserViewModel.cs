using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}