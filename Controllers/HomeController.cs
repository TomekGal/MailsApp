using MailsApp.Models.Domains;
using MailsApp.Models.Repositories;
using Microsoft.AspNet.Identity;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MailsApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private MailRepository _mailRepository = new MailRepository();
        

        public ActionResult Index( int statusId=1)
        {
            string heading;

            heading = SwitchStatus(statusId);

            var userId = User.Identity.GetUserId();
            var mails = _mailRepository.GetMails(userId, statusId);


            return View(mails);
        }

     
    
        public ActionResult SendMail(Mail mail)
        {

            string recipient = mail.SendTo;
            string subject = mail.Title;
            string body = mail.MailBody;

            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.SmtpPort = 587;
            WebMail.SmtpUseDefaultCredentials = false;
            WebMail.EnableSsl = true;
            WebMail.UserName = "tomekmvc@gmail.com";
            WebMail.Password = "xzofdvzvqempmhgr";

            WebMail.Send(to: recipient, subject: subject, body: body, isBodyHtml: true);

            var userId = User.Identity.GetUserId();
           
            var mailstatusId = 2;


            if (mail.Id == 0)
            {
                _mailRepository.Add(mail, userId, mailstatusId);
                return RedirectToAction("Index","Home", new { statusId= mailstatusId });
            }
            else
            {
                _mailRepository.Update(mail, userId, mailstatusId);
                return RedirectToAction("Index", "Home", new { statusId = mailstatusId });
            }
        }

       public ActionResult DeleteMail(int mailId=0)
        {

            var userId = User.Identity.GetUserId();
            var statusId = 5;
             _mailRepository.Delete(mailId, userId);
            var mails = _mailRepository.GetMails(userId, statusId);

          
            return RedirectToAction("Index", new { statusId = 5 });
        }

        public ActionResult MailNew(Mail mail)
        {
           
            return View(mail);
        }

        public ActionResult MailContent(int mailId)
        {
            var userId = User.Identity.GetUserId();
          
            var mail = _mailRepository.GetMail(mailId, userId);
            
          
            return View(mail);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string SwitchStatus(int statusId)
        {
            string heading;
            switch (statusId)
            {
                case 1:
                    heading = "Inbox";
                    ViewBag.Heading = heading;
                    break;
                case 2:
                    heading = "Sent";
                    ViewBag.Heading = heading;
                    break;
                case 3:
                    heading = "Draft";
                    ViewBag.Heading = heading;
                    break;
                case 4:
                    heading = "Spam";
                    ViewBag.Heading = heading;
                    break;
                case 5:
                    heading = "Bin";
                    ViewBag.Heading = heading;
                    break;
                default:
                    heading = "Inbox";
                    ViewBag.Heading = heading;
                    break;

            }

            return heading;
        }
    }
}