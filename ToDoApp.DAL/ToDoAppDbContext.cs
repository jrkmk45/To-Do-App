using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Models;

namespace ToDoApp.DAL
{
    public class ToDoAppDbContext : DbContext
    {
        public DbSet<ToDoTask> Tasks { get; set; }

        public ToDoAppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
