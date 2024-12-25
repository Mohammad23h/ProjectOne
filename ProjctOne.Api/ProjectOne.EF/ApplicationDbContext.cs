using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectOne.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.EF
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        

        public DbSet<Author> Authors { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Injurie> Injuries { get; set; }
        public DbSet<Nutrition> Nutritions { get; set; }
        public DbSet<ProfileInfo> ProfileInfos { get; set; }
        public DbSet<Program_Exercise> Program_Exercises { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<TrainingNutrition> TrainingNutritions { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }
        public DbSet<WorkoutProgram> WorkoutPrograms { get; set; }
    }
    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // تكوين العلاقة بين FeedBack و AppUser
        modelBuilder.Entity<FeedBack>()
            .HasOne(f => f.User)
            .WithMany(u => u.FeedBacks)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Restrict); // استخدام Restrict لتجنب الكاسكيد

        // تكوين العلاقة بين FeedBack و TrainingSession
        modelBuilder.Entity<FeedBack>()
            .HasOne(f => f.TrainingSession)
            .WithMany(ts => ts.FeedBacks)
            .HasForeignKey(f => f.SessionId)
            .OnDelete(DeleteBehavior.Restrict); // استخدام Restrict لتجنب الكاسكيد
    }*/
}
