using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Areas.Identity.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The Email is necessary")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Password is necessary")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }

    }
}