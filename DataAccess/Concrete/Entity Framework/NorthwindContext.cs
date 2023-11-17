using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entity_Framework
{
    //Context = DB tabloları ile proje classlarını bağlamak.
    public class NorthwindContext: DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//Bu fonksiyon yapılandırma için kullanılır, context nesnesi üzerinden override ederek erişilir ve düzenlenir.
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");//senin projen hangi veritabanıyla ilişkili onu belirteceğin yer.
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
