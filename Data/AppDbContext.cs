using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LightWeight.Data.Models;

namespace LightWeight.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("LightWeightDatabase"));
        }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<ExerciseTemplate> ExerciseTemplates { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<PrimaryMuscleGroup> PrimaryMuscleGroups { get; set; }
        public DbSet<WorkoutTemplate> WorkoutTemplates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>()
                .HasMany(u => u.Workouts)
                .WithOne(w => w.User)
                .HasForeignKey(w => w.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.WorkoutTemplates)
                .WithOne(wt => wt.User)
                .HasForeignKey(wt => wt.UserId);

            modelBuilder.Entity<Workout>()
                .HasMany(w => w.Exercises)
                .WithOne(e => e.Workout)
                .HasForeignKey(e => e.WorkoutId);

            modelBuilder.Entity<Exercise>()
                .HasMany(e => e.Sets)
                .WithOne(s => s.Exercise)
                .HasForeignKey(s => s.ExerciseId);

            modelBuilder.Entity<ExerciseTemplate>()
                .HasOne(et => et.Equipment)
                .WithMany(e => e.ExerciseTemplates)
                .HasForeignKey(et => et.EquipmentId);

            modelBuilder.Entity<ExerciseTemplate>()
                .HasOne(et => et.PrimaryMuscleGroup)
                .WithMany(pmg => pmg.ExerciseTemplates)
                .HasForeignKey(et => et.PrimaryMuscleGroupId);

            modelBuilder.Entity<ExerciseTemplate>()
                .HasMany(et => et.Exercises)
                .WithOne(e => e.ExerciseTemplate)
                .HasForeignKey(e => e.ExerciseTemplateId);

            modelBuilder.Entity<WorkoutTemplate>()
                .HasMany(wt => wt.ExerciseTemplates)
                .WithMany(et => et.WorkoutTemplates)
                .UsingEntity<Dictionary<string, object>>(
                "WorkoutTemplateExerciseTemplate",
                j => j.HasOne<ExerciseTemplate>().WithMany().HasForeignKey("ExerciseTemplateId"),
                j => j.HasOne<WorkoutTemplate>().WithMany().HasForeignKey("WorkoutTemplateId")
                );
        }
    }
}
