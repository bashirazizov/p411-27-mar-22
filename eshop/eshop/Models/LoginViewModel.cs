using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Models
{
    public class LoginViewModel
    {
        [Required, MaxLength(200)]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool KeepMeLoggedIn { get; set; }
    }
}
