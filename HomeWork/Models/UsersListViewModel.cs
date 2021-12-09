using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork.Models
{
    public class UsersListViewModel
    {
        public IEnumerable<UserListItemViewModel> Users { get; set; }
    }
}
