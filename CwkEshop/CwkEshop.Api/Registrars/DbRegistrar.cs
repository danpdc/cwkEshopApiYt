using CwkEshop.Dal;
using Microsoft.EntityFrameworkCore;

namespace CwkEshop.Api.Registrars
{
    public class DbRegistrar : IRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(cs));
        }
    }
}
