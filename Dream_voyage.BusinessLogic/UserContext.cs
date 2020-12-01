using System.Data.Entity;
using Dream_voyage.Domain;

namespace Dream_voyage.BusinessLogic
{
    public class UserContext : DbContext
    {
        public UserContext() :
           base("name = DreamVouyageDB") // connectionstring name define in your web.config
        {
        }

        public virtual DbSet<DVUser> Users { get; set; }
    }
}
