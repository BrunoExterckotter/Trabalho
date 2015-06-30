using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CriarPessoa.ProjetoWeb.Startup))]
namespace CriarPessoa.ProjetoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
