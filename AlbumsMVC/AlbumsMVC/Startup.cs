using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlbumsMVC.Startup))]
namespace AlbumsMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
