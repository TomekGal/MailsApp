using System.ComponentModel.DataAnnotations;

namespace MailsApp.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
