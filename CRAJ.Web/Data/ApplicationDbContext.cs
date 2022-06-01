using CRAJ.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAJ.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Document> Document { get; set; }
        public DbSet<TypeDoc> TypeDoc { get; set; }
        public DbSet<Chambre> Chambre { get; set; }
        public DbSet<Tribunal> Tribunal { get; set; }
        public DbSet<Magasin> Magasin{ get; set; }
    }
}
