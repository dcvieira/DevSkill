using DevSkill.Application.Contracts;
using DevSkill.Domain.Catalog.Entities;
using DevSkill.Domain.Common;
using DevSkill.Domain.Order.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevSkill.Persistence;
public class DevSkillDbContext : DbContext
{
    private readonly ILoggedInUserService _loggedInUserService;


    public DevSkillDbContext(DbContextOptions<DevSkillDbContext> options, ILoggedInUserService loggedInUserService)
        : base(options)
    {
        _loggedInUserService = loggedInUserService;
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DevSkillDbContext).Assembly);

        //seed data, added through migrations
        var webDeve = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
        var dataScience = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
        var mobile = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
        var backend = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = webDeve,
            Name = "Web Development",
            CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now,
            CreatedBy = "System",
            LastModifiedBy = "System"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = dataScience,
            Name = "Data Science",
                 CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now,
            CreatedBy = "System",
            LastModifiedBy = "System"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = mobile,
            Name = "Mobile Development",
                 CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now,
            CreatedBy = "System",
            LastModifiedBy = "System"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = backend,
            Name = "Backend Development",
                 CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now,
            CreatedBy = "System",
            LastModifiedBy = "System"
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            Id = Guid.Parse("{812941fc-d06d-4158-80a9-e3c3b13a7c0b}"),
            Description = "Description of Curso de C#",
            Name = "Curso de C#",
            Price = 100,
            ImageUrl = "https://img-c.udemycdn.com/course/240x135/1581488_e3e1_2.jpg",
            Duration = 10,
            CategoryId = backend,
            CreatedDate =  DateTime.Now,
            LastModifiedDate = DateTime.Now,
            CreatedBy = "System",
            LastModifiedBy = "System"
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            Id = Guid.Parse("{b6aff6ab-a6a4-46ba-bd86-8031f21d7796}"),
            Description = "Description of Curso de Python",
            Name = "Curso de Python",
            Price = 200,
            ImageUrl = "https://img-c.udemycdn.com/course/240x135/567828_67d0.jpg",
            Duration = 25,
            CategoryId = dataScience,
            CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now,
            CreatedBy = "System",
            LastModifiedBy = "System"
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            Id = Guid.Parse("{6ab7ba3c-330d-48a9-8c3f-21e72931f6d2}"),
            Description = "Curso de HTML 5 COMPLETO e com Projetos Práticos para WEB",
            Name = "Curso de HTML 5 COMPLETO e com Projetos Práticos para WEB",
            Price = 350,
            ImageUrl = "https://img-b.udemycdn.com/course/240x135/2231672_d36d_4.jpg",
            Duration = 46,
            CategoryId = webDeve,
            CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now,
            CreatedBy = "System",
            LastModifiedBy = "System"
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            Id = Guid.Parse("{7490207f-edff-4201-9e67-95ad48225358}"),
            Description = "HTML e CSS Essencial -Front End Completo para Iniciantes",
            Name = "HTML e CSS Essencial -Front End Completo para Iniciantes",
            Price = 110,
            ImageUrl = "https://img-c.udemycdn.com/course/240x135/1755476_2755_5.jpg",
            Duration = 46,
            CategoryId = webDeve,
            CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now,
            CreatedBy = "System",
            LastModifiedBy = "System"
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            Id = Guid.Parse("{a20964c4-e972-46e7-9cab-99e325cdae0e}"),
            Description = "Web Design: Construa Sites com PHP, HTML, CSS e JavaScript",
            Name = "Web Design: Construa Sites com PHP, HTML, CSS e JavaScript",
            Price = 70,
            ImageUrl = "https://img-c.udemycdn.com/course/240x135/1586752_2d9e_2.jpg",
            Duration = 120,
            CategoryId = webDeve,
            CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now,
            CreatedBy = "System",
            LastModifiedBy = "System"
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            Id = Guid.Parse("{ba24d51f-2946-4fa5-8006-a29af5b84b4d}"),
            Description = "Python for Data Science and Machine Learning Bootcamp",
            Name = "Python for Data Science and Machine Learning Bootcamp",
            Price = 87,
            ImageUrl = "https://img-c.udemycdn.com/course/240x135/1586752_2d9e_2.jpg",
            Duration = 100,
            CategoryId = dataScience,
            CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now,
            CreatedBy = "System",
            LastModifiedBy = "System"
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            Id = Guid.Parse("{8816ca0b-73a1-4844-aa00-ad0234507d74}"),
            Description = "Flutter - Beginners Course",
            Name = "Flutter - Beginners Course",
            Price = 120,
            ImageUrl = "https://img-c.udemycdn.com/course/240x135/1586752_2d9e_2.jpg",
            Duration = 43,
            CategoryId = mobile,
            CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now,
            CreatedBy = "System",
            LastModifiedBy = "System"
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = _loggedInUserService.UserId;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}

