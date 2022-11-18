using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MailsApp.Models.Domains
{
    public class Mail
    {

       
        public int Id { get; set; }

        [Required]
        [Display(Name ="Tytuł")]
        public string Title { get; set; }

        [Display(Name ="Treść wiadomości")]
        public string MailBody { get; set; }
		
		
        public DateTime SentDate { get; set; }

        //[Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
      [Required]
        public int MailStatusId { get; set; }

        [Required, EmailAddress]
        [Display(Name ="Wyślij do")]
        public string SendTo { get; set; }

        
        public string RecivedFrom { get; set; }

        public ApplicationUser User { get; set; }

      
        public MailStatus MailStatus { get; set; }

        
       
    }
}