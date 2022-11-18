using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MailsApp.Startup))]
namespace MailsApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
