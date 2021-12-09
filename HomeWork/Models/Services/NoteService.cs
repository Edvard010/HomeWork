using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork.Models;
using HomeWork.Models.Entities;
using HomeWork.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Models.Services
{
    public class NoteService
    {
        private AppDbContext _context;
        private UserManager<CustomUser> _userManager;

        public NoteService(AppDbContext context, UserManager<CustomUser> userManager)
        {
            _userManager = userManager;
            _context = context; 
        }
          
              

        public EditNoteViewModel GetToEdit(int id)
        {
            var note = _context.Notes.Find(id);

            var vm = new EditNoteViewModel
            {
                Name = note.Name,
                Description = note.Description
            };

            return vm;
        }
        public void Update(EditNoteViewModel updated)
        {
            var note = _context.Notes.Find(updated.Id);
            
            note.Name = updated.Name;
            note.Description = updated.Description;

            _context.Update(note);
            _context.SaveChanges();
        }

        public void RemoveNote(int id)
        {
            var note = _context.Notes.Find(id);

            _context.Notes.Remove(note);

            _context.SaveChanges();
        }
    }
}
