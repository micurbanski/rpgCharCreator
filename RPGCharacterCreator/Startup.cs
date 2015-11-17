using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RPGCharacterCreator.Startup))]
namespace RPGCharacterCreator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
