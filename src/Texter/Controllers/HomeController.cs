using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Texter.Models;


namespace Texter.Controllers
{
    public class HomeController : Controller
    {
        private readonly TexterDbContext _db;

        public HomeController(TexterDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        //To view all the messages: it will be a standard GET request.
        public IActionResult GetMessages()
        {
            var allMessages = Message.GetMessages();
            return View(allMessages);
        } 

        //To Send a message:  this will be a POST request.
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message newMessage)
        {
            newMessage.Send();
            return RedirectToAction("Index");
        }


        //ajax method to display contact

        public IActionResult DisplayContact()
        {
            Contact contact = new Contact("Bill", "+12065546435", 1);
            return Json(contact);
        } 

        [HttpPost]
        public IActionResult AddContact(string Name, string PhoneNumber)
        {
            Contact newContact = new Contact(Name, PhoneNumber);
            _db.Contacts.Add(newContact);
            _db.SaveChanges();
            return Json(newContact);
        }
    }
}
