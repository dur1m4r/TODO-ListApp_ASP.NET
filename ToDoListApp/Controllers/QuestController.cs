using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{

    public class QuestController : Controller
    {
        private readonly ToDoContext _context;

        public QuestController(ToDoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Quests.ToList());
        }
    
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Quest quest = _context.Quests.SingleOrDefault(x => x.ID == id);
            if (quest == null)
            {
                return NotFound();
            }

            _context.Remove(quest);
            _context.SaveChanges();

            TempData["message"] = "Person deleted";
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult Add(string add)
        {
            if (add != null)
            { 
                Quest quest = new Quest { QuestName = add, isDone = false, isImportant = false };
                _context.Add(quest);
                _context.SaveChanges();

                return RedirectToAction("Index");
            } else
            {
                return RedirectToAction("Index");

            }
        }
        public IActionResult Important(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Quest quest = _context.Quests.SingleOrDefault(x => x.ID == id);
            if (quest == null)
            {
                return NotFound();
            }
            if (quest.isImportant == true)
            {
                quest.isImportant = false;
                _context.SaveChanges();
            } else
            {
                quest.isImportant = true;
                _context.SaveChanges();
            }
            TempData["state"] = 0;
            return RedirectToAction("Index");
        }

        public IActionResult Done(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Quest quest = _context.Quests.SingleOrDefault(x => x.ID == id);
            if (quest == null)
            {
                return NotFound();
            }
            if (quest.isDone == true)
            {
                quest.isDone = false;
                _context.SaveChanges();
            }
            else
            {
                quest.isDone = true;
                _context.SaveChanges();
            }
            TempData["state"] = 0;
            return RedirectToAction("Index");
        }
        public IActionResult All()
        {
            TempData["state"] = 0;
            return RedirectToAction("Index");
        }
        public IActionResult doneList()
        {
            TempData["state"] = 2;
            return RedirectToAction("Index");
        }
        public IActionResult Active()
        {
            TempData["state"] = 1;
            return RedirectToAction("Index");
        }
        public IActionResult SearchBtn(string search)
        {
            if (search != null)
            {
                TempData["stringToSearch"] = search;
                TempData["state"] = 3;
                return RedirectToAction("Index");
            } else
            {
                return RedirectToAction("Index");
            }

        }
    }
}