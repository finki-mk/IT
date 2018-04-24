using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AudMvc5.Startup))]
namespace AudMvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
