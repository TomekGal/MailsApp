using MailsApp.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace MailsApp.Models.Repositories
{
    public class MailRepository
    {
        public List<Mail> GetMails(string userId, int statusId)
        {

            using (var context = new ApplicationDbContext())
            {
                return context.Mails.Where(x => x.UserId == userId && x.MailStatusId == statusId).ToList();
            }

        }



        public void Add(Mail mail, string userId,int mailstatusId)
        {
            using (var context = new ApplicationDbContext())
            {
                mail.SentDate = DateTime.Now;
                mail.UserId = userId;
                mail.MailStatusId = mailstatusId;
                context.Mails.Add(mail);
                context.SaveChanges();
            }
        }

        public Mail GetMail(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Mails
                    .Include(x => x.MailStatus)
                    .Include(x => x.User)
                    .Single(x => x.Id == id && x.UserId == userId);

            }

        }

        public List<MailStatus> GetMailStatus()
        {

            using (var context = new ApplicationDbContext())
            {
                return context.MailStatuses.ToList();
            }
        }

        public void Delete(int mailId, string userId)
        {
            using (var context = new ApplicationDbContext())
            {

               var delmail= context.Mails.Where(x => x.Id == mailId && x.UserId==userId).Single();
                delmail.MailStatusId = 5;
                context.SaveChanges();
             }

        }

        public void Update(Mail mail, string userId, int mailstatusId)
        {
            using (var context = new ApplicationDbContext())
            {
                var updateMail = context.Mails.Single(x => x.Id == mail.Id && x.UserId == userId);

                updateMail.MailBody = mail.MailBody;
                updateMail.Title = mail.Title;
                updateMail.MailStatusId = mailstatusId;
                updateMail.SendTo = mail.SendTo;
                
                context.SaveChanges();

            }
        }
    }
}
