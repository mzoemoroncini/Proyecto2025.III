using Proyecto2025.III.BD.Datos;
using Microsoft.EntityFrameworkCore;

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Proyecto2025.III.BD.Datos.Entity
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Caso> Casos { get; set; }
        public DbSet<CasoPersona> CasosPersona { get; set; }
      
        public DbSet<Persona> Personas { get; set; }
        
        public DbSet<TipoDocumentacion> TipoDocumentos { get; set; }
        public DbSet<Documentacion> Documentacions { get; set; }

       

        public AppDBContext(DbContextOptions<AppDBContext> options)
         : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var cascadeFKs = modelBuilder.Model
                .G­etEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }
            

            // ---------------------------
            // Enums como string
            // ---------------------------

            modelBuilder.Entity<Caso>()
                .Property(c => c.Estado)
                .HasConversion<string>();

            modelBuilder.Entity<Caso>()
                .Property(c => c.Tipo)
                .HasConversion<string>();
           
        }
    }
}

