using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserApp.Models;

namespace UserApp.Controllers
{
    public class UserController : Controller
    {
       
        public static List<User> users=new List<User>();
        
        public IActionResult Index()
        {
            //users.Add(new User() { Id = 1, Name = "ABC" ,Address="pune" });
            //users.Add(new User() { Id = 2, Name = "DEF", Address = "HYD" });
            //users.Add(new User() { Id = 3, Name = "XYZ", Address = "BDR" });
            //users.Add(new User() { Id = 4, Name = "PQRS", Address = "BLK" });



            return View(users);
        }
        [HttpGet]
        public IActionResult create()
        {
            User user= new User();
            
            return View(user);
        }
        public IActionResult create(User user)
        {
       
            users.Add(user);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
            {
            var user=users.FirstOrDefault(user=>user.Id==id);
            users.Remove(user);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = users.FirstOrDefault(user => user.Id == id);

            return View(user);
        }
        [HttpPost]
        public IActionResult Update(User user)
        {
            var user1   = users.FirstOrDefault(u=> u.Id ==user.Id);

            user1.Name=user.Name;
            user1.Address=user.Address;
            return RedirectToAction("Index");
        }
    }
}