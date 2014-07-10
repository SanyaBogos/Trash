using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextInterProj2.Models;
using System.Data.Entity;

namespace NextInterProj2.Controllers
{
    public class ChatController : Controller
    {
        //
        // GET: /Chat/
        UsersContext db = new UsersContext();

        public ActionResult Index()
        {
            var messages = db.Chats.Include(m => m.Sender);
            return View(messages.ToList());
        }

    }
}
