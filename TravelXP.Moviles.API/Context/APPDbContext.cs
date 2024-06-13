using Microsoft.EntityFrameworkCore;
using TravelXP.Moviles.API.Models;
using MySql.Data.MySqlClient;

namespace TravelXP.Moviles.API.Context
{
    public class APPDbContext(DbContextOptions<APPDbContext> options) : DbContext(options)
    {
        public DbSet<UsuarioAttributes> Usuarios { get; set; } = default!;
        public DbSet<SeguidoresAttributes> Seguidores { get; set; } = default!;
        public DbSet<PublicacionesAttributes> Publicaciones { get; set; } = default!;
        public DbSet<LikesAttributes> Likes { get; set; } = default!;
        public DbSet<ComentariosAttributes> Comentarios { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de UsuarioAttributes
            modelBuilder.Entity<UsuarioAttributes>(entity =>
            {
                entity.HasKey(e => e.Id_usuario); // Clave primaria
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Nombre_usuario).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Contrasena).IsRequired().HasMaxLength(100);
            });

            // Configuración de SeguidoresAttributes
            modelBuilder.Entity<SeguidoresAttributes>(entity =>
            {
                entity.HasKey(e => e.Id_usuario); // Clave primaria
                entity.Property(e => e.SeguidorID).IsRequired();
                entity.Property(e => e.Fecha_seguimiento).IsRequired();
            });

            // Configuración de PublicacionesAttributes
            modelBuilder.Entity<PublicacionesAttributes>(entity =>
            {
                entity.HasKey(e => e.Id); // Clave primaria
                entity.Property(e => e.Id_usuario).IsRequired();
                entity.Property(e => e.Fecha).IsRequired();
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.Tipo_publicacion).HasMaxLength(50);
                entity.Property(e => e.Ubicacion).HasMaxLength(100);
            });

            // Configuración de LikesAttributes
            modelBuilder.Entity<LikesAttributes>(entity =>
            {
                entity.HasKey(e => e.Id); // Clave primaria
                entity.Property(e => e.Id_usuario).IsRequired();
                entity.Property(e => e.Id_Publicacion).IsRequired();
                entity.Property(e => e.Fecha).IsRequired();
            });

            // Configuración de ComentariosAttributes
            modelBuilder.Entity<ComentariosAttributes>(entity =>
            {
                entity.HasKey(e => e.Id); // Clave primaria
                entity.Property(e => e.Id_publicacion).IsRequired();
                entity.Property(e => e.Id_usuario).IsRequired();
                entity.Property(e => e.Contenido).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.Fecha).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
