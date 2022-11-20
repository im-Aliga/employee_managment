
using EmployeeManagment_.Database.Contexts;

namespace EmployeeManagment_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMvc();


            var app = builder.Build();
            app.UseStaticFiles();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}");

            app.Run();


            
        }
    }
}