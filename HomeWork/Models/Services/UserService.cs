using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace HomeWork.Models.Services
{
    public class UserService
    {
        private AppDbContext _context;


        public UserService(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<UserListItemViewModel> GetAll()
        {
            var users = _context.UsersCustom.Select(x => new UserListItemViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Login = x.UserName
            }).ToList();

            return users;
        }

        

        public EditUserViewModel GetToEdit(int id)
        {
            var user = _context.UsersCustom.Find(id);
            
            var vm = new EditUserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AboutMe = user.AboutMe,              
            };

            return vm;
        }

        public void Update(EditUserViewModel updated)
        {
            var user = _context.UsersCustom.Find(updated.Id);

            user.FirstName = updated.FirstName;
            user.LastName = updated.LastName;
            user.AboutMe = updated.AboutMe;

            _context.Update(user);
            _context.SaveChanges();
        }

        public ViewUserViewModel GetToView(int id)
        {
            var user = _context.UsersCustom.Find(id);
            var notes = _context.Notes.Where(x => x.CustomUserId == id).ToList();
            var vm = new ViewUserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AboutMe = user.AboutMe,
                Notes = notes
            };

            return vm;
        }

        public void Remove(int id)
        {
            var user = _context.Users.Find(id);

            _context.Users.Remove(user);

            _context.SaveChanges();
        }
    }
}
