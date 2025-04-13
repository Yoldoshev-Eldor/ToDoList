using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Entities;

namespace ToDoList.DataAccess
{
    public class MainContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }
    }
}
