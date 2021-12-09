using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork.Models
{
    public class AddNoteViewModel
    {
        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [Display(Name = "Tytuł")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Treść jest wymagana")]
        [Display(Name = "Notatka")]
        public string Description { get; set; }
    }
}
