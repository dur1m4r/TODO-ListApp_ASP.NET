using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Models;

namespace ToDoListApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(ToDoContext context)
        {
            context.Database.EnsureCreated();

            if (context.Quests.Any())
            {
                return;
            }
            var quests = new Quest[]
            {
                new Quest {QuestName = "Save a village", isDone = false, isImportant = false},
                new Quest {QuestName = "Do laundry", isDone = false, isImportant = true},
                new Quest {QuestName = "Kill the Dragon", isDone = false, isImportant = false},
                new Quest {QuestName = "Read a book", isDone = true, isImportant = true}

            };

            foreach (Quest q in quests)
            {
                context.Quests.Add(q);
            }
            context.SaveChanges();
        }
    }
}
