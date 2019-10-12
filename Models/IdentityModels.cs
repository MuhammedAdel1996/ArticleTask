using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ArticleTask.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ArticleTaskDB", throwIfV1Schema: false)
        {
        }
        public virtual DbSet<Article> Articles { set; get; }
        public virtual DbSet<ArticleCategory> ArticleCategories { set; get; }
        public virtual DbSet<Comments> Comments { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasRequired(a => a.ArticleCategory).WithMany(a => a.Articles).HasForeignKey(a => a.categoryid).WillCascadeOnDelete();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comments>().HasRequired(c => c.Article).WithMany(a => a.Comments).HasForeignKey(c => c.articaleid);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}