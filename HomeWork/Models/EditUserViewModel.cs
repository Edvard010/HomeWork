using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork.Models
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AboutMe { get; set; }
    }
}
