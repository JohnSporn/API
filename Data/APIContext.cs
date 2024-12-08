using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class APIContext : DbContext
    {
        public APIContext (DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public DbSet<SystemUser> SystemUser { get; set; } = default!;
        public DbSet<API.Models.Budget> Budget { get; set; } = default!;
        public DbSet<API.Models.Category> Category { get; set; } = default!;
        public DbSet<API.Models.Expense> Expense { get; set; } = default!;
        public DbSet<API.Models.Income> Income { get; set; } = default!;
        public DbSet<API.Models.RecurringExpense> RecurringExpense { get; set; } = default!;
    }
}
