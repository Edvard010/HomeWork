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

namespace HomeWork.Controllers
{
    public class NoteController : Controller
    {
        private NoteService _noteService;
        private AppDbContext _context;
        private UserManager<CustomUser> _userManager;


        public NoteController(AppDbContext context, NoteService noteService, UserManager<CustomUser> userManager)
        {
            _noteService = noteService;
            _context = context;
            _userManager = userManager;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddNoteViewModel data)
        {
            
            CreateNote(data.Name, data.Description);

            return RedirectToAction("Index", "Home");

        }

        public void CreateNote(string name, string description) 
        {
            var userId = _userManager.GetUserId(User);
            int.TryParse(userId, out int id);
            var user = _context.UsersCustom.Find(id);

            var entity = new NoteEntity
            {
                Name = name,
                Description = description,
                CustomUser = user
            };
            _context.Notes.AddAsync(entity);
            user.Notes.Add(entity);
            _context.SaveChanges();
        }

        [Route("api/controller/Edit/{id}")]
        [HttpGet]        
        public IActionResult Edit(int id)
        {
            var vm = _noteService.GetToEdit(id);
            return View(vm);
        }
                
        [HttpPost]    
        public IActionResult Update(EditNoteViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            _noteService.Update(data);
            return RedirectToAction("ViewUser", "User");
        }
                  
        public IActionResult Remove(int id)
        {
            _noteService.RemoveNote(id);
            return RedirectToAction("ViewUser", "User");
        }

    }
}
