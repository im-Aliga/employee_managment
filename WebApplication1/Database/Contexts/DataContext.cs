using EmployeeManagment_.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment_.Database.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-J810F6D;Database=EmployeesData;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Employee> Employees { get; set; }




    }
    public class EmployeeCodeAutoincrement
    {
        static Random _random = new Random();
        private static string _blogCode;

        public static string BlogCode
        {
            get
            {
                DataContext dbContexts = new DataContext();
                var employees = dbContexts.Employees.ToList();

                bool go = true;
                string newCode = "E" + _random.Next(1000, 10000);



                while (go)
                {
                    int lastId = 0;


                    foreach (Employee employee in employees)
                    {
                        if (employee.EmployeeCode == newCode)
                        {
                            newCode = "E" + _random.Next(1000, 10000);

                        }
                        lastId++;
                    }

                    if (lastId == employees.Count)
                    {
                        go = false;

                    }

                }


                return newCode;
            }


        }

    }

}