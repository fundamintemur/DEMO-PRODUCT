using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
   
  public class Context :IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LENOVO\\SQLEXPRESS;database=DbNewOopCore1;integrated security=true;");
        }
        //aslında  burda yaptığımız entity oluşturduğumuz  classları db tanımladık yani veri bağlantıs yaptığımız yerde
        //ilk kısım c# class adı,ikinci kısım ise sql de karışılığı..

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Job> Jobs { get; set; }

    }
}
