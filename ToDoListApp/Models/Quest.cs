using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApp.Models
{
    public class Quest
    {
        public int ID { get; set; }
        public string QuestName { get; set; }
        public bool isImportant { get; set; }
        public bool isDone { get; set; }
    }
}
