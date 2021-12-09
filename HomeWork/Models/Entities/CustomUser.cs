using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork.Models.Entities
{
    public class CustomUser : IdentityUser<int>
    {
        

        //IdentityUser ma pole "Id", ale był błąd przy migracji: 
        //The relationship from 'UserNoteEntity.User' to 'CustomUser.UserNote' with foreign key properties {'UserId' : int} 
        //cannot target the primary key {'Id' : string} because it is not compatible. 
        //Configure a principal key or a set of compatible foreign key properties for this relationship. TU SE
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AboutMe { get; set; }
        public List<NoteEntity> Notes { get; set; }
        
    }
}
