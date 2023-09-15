using exercise_planner.Models.DbModels;
using exercise_planner.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace exercise_planner.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("exercise_plannerConnectionString") { }
        public DbSet<User> User { get; set;}
        public DbSet<Exercise> Exercise { get; set;}
        public DbSet<Plan> Plan { get; set;}
        public DbSet<ExDetails> ExDetails { get; set;}
        public DbSet<Plan_Ex> Plan_Ex { get; set; }
    }
}