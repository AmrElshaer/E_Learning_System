using Microsoft.AspNet.Identity.EntityFramework;

namespace ELearning.Infrasturcture.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
           : base("name=ApplicationUsers")
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
