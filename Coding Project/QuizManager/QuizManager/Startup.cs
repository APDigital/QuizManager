using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuizManager.Startup))]
namespace QuizManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
