using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Huertos_Autosustentables_PI.Models;

namespace Huertos_Autosustentables_PI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Huertos_Autosustentables_PI.Models.Clima> Clima { get; set; }
        public DbSet<Huertos_Autosustentables_PI.Models.Cultivo> Cultivo { get; set; }
        public DbSet<Huertos_Autosustentables_PI.Models.TipoCultivo> TipoCultivo { get; set; }
        public DbSet<Huertos_Autosustentables_PI.Models.Region> Region { get; set; }
        public DbSet<Huertos_Autosustentables_PI.Models.DetalleUsersCultivo> DetalleUsersCultivo { get; set; }
    }
}
