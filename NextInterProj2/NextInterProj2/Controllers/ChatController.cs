using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextInterProj2.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace NextInterProj2.Controllers
{
    public class ChatController : Controller
    {
        //
        // GET: /Chat/
        UsersContext db = new UsersContext();

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var messages = db.Chats.Include(m => m.Reciever);
            messages = messages.Include(n => n.Sender);
            return View(messages.ToList());
        }

        [Authorize]
        public ActionResult Message()
        {
            var people = db.UserProfiles;
            return View(people.ToList());
        }

        [Authorize]
        public ActionResult Say(int? recieverId)
        {
            //if (recieverId == null)
            //    return HttpNotFound();
            int sendId = (int)WebMatrix.WebData.WebSecurity.CurrentUserId;

            int senderId = Convert.ToInt32(User.Identity.GetUserId());
            var messages = db.Chats.Include(m => m.Reciever).Include(n => n.Sender).Where(s => s.SenderUserId == senderId
                && s.RecieverUserId == recieverId);
            return View(messages.ToList());
        }
    }
}
