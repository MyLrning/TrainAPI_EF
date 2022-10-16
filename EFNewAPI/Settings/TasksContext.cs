using EFNewAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFNewAPI.Settings;

public class TasksContext : DbContext
{
    public DbSet<Duty> Tasks { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TasksDB;Trusted_Connection=True;");
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> initCategories = new()
        {
            new Category {Id = 1, Name = "Work", Description = "Work related tasks", Weight = 1},
            new Category {Id = 2, Name = "Home", Description = "Home related tasks", Weight = 2},
            new Category {Id = 3, Name = "Hobby", Description = "Hobby related tasks", Weight = 3},
            new Category {Id = 4, Name = "Other", Description = "Other tasks", Weight = 4}
        };
        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(c => c.Id);
            category.Property(c => c.Id).ValueGeneratedOnAdd();
            category.Property(c => c.Name).IsRequired().HasMaxLength(150);
            category.Property(c => c.Description).IsRequired(false);
            category.Property(c => c.Weight).IsRequired();
            category.HasData(initCategories);
        });

        List<Duty> initDuties = new()
        {
            new Duty
            {
                Id = 1,
                CategoryId = 1,
                Title = "Learn EF Core",
                Priority = Priority.High,
                CreateDate = DateTime.Now,
                Deadline = DateTime.Now.AddDays(7),
            },
            new Duty
            {
                Id = 2,
                CategoryId = 2,
                Title = "Clean the house",
                Description = "Clean the house",
                Priority = Priority.High,
                CreateDate = DateTime.Now,
                Deadline = DateTime.Now.AddDays(7),
            },
            new Duty
            {
                Id = 3,
                CategoryId = 1,
                Title = "Learn ASP.NET Core",
                Description = "Learn ASP.NET Core",
                Priority = Priority.High,
                CreateDate = DateTime.Now,
                Deadline = DateTime.Now.AddDays(7),
            },
            new Duty
            {
                Id = 4,
                CategoryId = 1,
                Title = "Learn Blazor",
                Description = "Learn Blazor",
                Priority = Priority.High,
                CreateDate = DateTime.Now,
                Deadline = DateTime.Now.AddDays(7),
            }
        };

        modelBuilder.Entity<Duty>(duty =>
        {
            duty.ToTable("Duty");
            duty.HasKey(d => d.Id);
            duty.Property(d => d.Id).ValueGeneratedOnAdd();
            duty.Property(d => d.Title).IsRequired().HasMaxLength(200);
            duty.Property(d => d.Description).IsRequired(false);
            duty.Property(d => d.Priority);
            duty.Property(d => d.CreateDate);
            duty.Property(d => d.Deadline);
            duty.HasData(initDuties);
            duty.HasOne(c => c.Category).WithMany(d => d.Duties).HasForeignKey(d => d.CategoryId);
            duty.Ignore(d => d.Summary);
        });
    }
}

