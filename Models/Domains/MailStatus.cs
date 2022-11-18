using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MailsApp.Models.Domains
{
    public class MailStatus
    {
        public MailStatus()
        {
            Mails = new Collection<Mail>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Mail> Mails { get; set; }
    }
}