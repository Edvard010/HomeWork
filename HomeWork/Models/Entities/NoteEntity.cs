using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;


namespace HomeWork.Models.Entities
{
    public class NoteEntity
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CustomUserId { get; set; }
        public CustomUser CustomUser { get; set; }
    }
}
