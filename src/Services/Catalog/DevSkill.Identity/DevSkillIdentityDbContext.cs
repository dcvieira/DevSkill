using DevSkill.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevSkill.Identity;
    public class DevSkillIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public DevSkillIdentityDbContext()
        {

        }

        public DevSkillIdentityDbContext(DbContextOptions<DevSkillIdentityDbContext> options) : base(options)
        {
        }
    }

