using Microsoft.AspNetCore.Mvc;
using ToDoList.DataBase;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private int _id {  get; set; }
        private readonly Db _db;
        public ToDoController(Db db) 
        {
            _db = db;
        }
        public IActionResult Mission(Account account)
        {
            _id = account.Id;
            List<Mission> missions=_db.missions.ToList();
            List<Mission> missionAccount = new List<Mission>();
            foreach (Mission mission in missions) 
            {
                if(mission.AccountId==_id)
                {
                    missionAccount.Add(mission);
                }
            }
            ViewData["id"] = _id;
            return View(missionAccount);
        }
        public IActionResult Create(int id)
        {
            ViewData["id"] = id;
            return View();
        }
        [HttpPost]
        public IActionResult CheckCreate(Mission? mission,int id)
        {          
            if(mission.Content!=null&&mission.Name!=null&&mission.Note!=null)
            {
                mission.AccountId = id;

                if (ModelState.IsValid)
                {
                    _db.missions.Add(mission);
                    _db.SaveChanges();


                }
            }
              
            Account a =_db.accounts.Find(id);
            return RedirectToAction("Mission",a);
        }
        public IActionResult Delete(string Name)
        {
            if (Name == null)
            {
                return NotFound();
            }
            var mission = _db.missions.Find(Name);
            if (mission == null)
            {
                return NotFound();
            }
            return View(mission);
        }
        
    }
}
