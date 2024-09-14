
using System.Collections.Generic;
using lib_admin.Models;
using Microsoft.EntityFrameworkCore;

namespace lib_admin.Data
{
    internal class LibraryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-RFGQSC7;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<Models.Lib> Libs { get; set; }
        public DbSet<Models.Book> Books { get; set; }
        
        
    }
    

}
