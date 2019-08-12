using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyFirstApi.Models
{
    public class ApiContext:DbContext
    {
        public ApiContext()
        {
            Database.SetInitializer<ApiContext>(new DropCreateDatabaseIfModelChanges<ApiContext>());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Perfil> Profiles { get; set; }
        public DbSet<RolUser> Roles { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}