using System.Data.Entity;
using MailsApp.Models.Domains;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MailsApp.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Mail> Mails { get; set; }
       
        public DbSet<MailStatus> MailStatuses { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.Mails)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);

           

            base.OnModelCreating(modelBuilder);
        }
    }
}