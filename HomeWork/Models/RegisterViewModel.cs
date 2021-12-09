using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HomeWork.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Imię jest wymagane")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Login jest wymagany")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [Display(Name = "Powtórz hasło")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "O mnie")]
        public string AboutMe { get; set; }

        [Display(Name = "Awatar")]
        public IFormFile Avatar { get; set; }

        public bool PasswordConfirmed()
        {
            return Password == ConfirmPassword;
        }
    }
}
