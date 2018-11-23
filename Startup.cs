using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using darksharddesign_server.Models;

namespace darksharddesign_server
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services) 
    {
      services.AddDbContext<TodoContext>(opt =>
        opt.UseInMemoryDatabase("TodoList"));

      services.AddMvc()
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseMvc();
    }
  }
}
