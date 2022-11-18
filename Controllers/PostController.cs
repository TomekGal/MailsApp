using MailsApp.Models;
using MailsApp.Models.Domains;
using MailsApp.Models.Repositories;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace MailsApp.Controllers
{
    public class PostController : Controller
    {
        private MailRepository _mailRepository = new MailRepository();

        [MultiButtonActionHandler]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveDraft(Mail mail)
        {


            if (!ModelState.IsValid)
            {
                return RedirectToAction("MailNew", "Home", mail);
            }
            var userId = User.Identity.GetUserId();
            var mailstatusId = 3;
            if (mail.Id != 0)
            {
               
                _mailRepository.Update(mail, userId, mailstatusId);
                return RedirectToAction("Index", "Home", new { statusId = mailstatusId });
            }
            else
            {
               
                _mailRepository.Add(mail, userId, mailstatusId);
            }


            return RedirectToAction("Index", "Home", new { statusId = mail.MailStatusId });
        }

        [MultiButtonActionHandler]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Send(Mail mail)
        {

            return RedirectToAction("SendMail", "Home",mail);
        }

        [MultiButtonActionHandler]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Cancel()
        {
            return RedirectToAction("Index","Home");
        }

        public ActionResult Action()
        {
            return RedirectToAction("Index", "Home");
        }


    }
}