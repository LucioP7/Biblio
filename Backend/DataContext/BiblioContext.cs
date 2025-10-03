using Microsoft.EntityFrameworkCore;
using Service.Enums;
using Service.Models;

namespace Backend.DataContext;
public class BiblioContext : DbContext
{
    public BiblioContext()
    {
    }

    public BiblioContext(DbContextOptions<BiblioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autores { get; set; }
    public virtual DbSet<Carrera> Carreras { get; set; }
    public virtual DbSet<Editorial> Editoriales { get; set; }
    public virtual DbSet<Ejemplar> Ejemplares { get; set; }
    public virtual DbSet<Genero> Generos { get; set; }
    public virtual DbSet<Libro> Libros { get; set; }
    public virtual DbSet<LibroAutor> LibroAutores { get; set; }
    public virtual DbSet<LibroGenero> LibroGeneros { get; set; }
    public virtual DbSet<Prestamo> Prestamos { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<UsuarioCarrera> UsuarioCarreras { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();
        var cadenaConexion = configuration.GetConnectionString("mysqlRemoto");

        optionsBuilder.UseMySql(cadenaConexion, ServerVersion.AutoDetect(cadenaConexion));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region datos semillas de 10 autores
        modelBuilder.Entity<Autor>().HasData(
            new Autor { Id = 1, Nombre = "Gabriel García Márquez" },
            new Autor { Id = 2, Nombre = "Isabel Allende" },
            new Autor { Id = 3, Nombre = "Mario Vargas Llosa" },
            new Autor { Id = 4, Nombre = "Jorge Luis Borges" },
            new Autor { Id = 5, Nombre = "Pablo Neruda" },
            new Autor { Id = 6, Nombre = "Julio Cortázar" },
            new Autor { Id = 7, Nombre = "Laura Esquivel" },
            new Autor { Id = 8, Nombre = "Carlos Fuentes" },
            new Autor { Id = 9, Nombre = "Miguel de Cervantes" },
            new Autor { Id = 10, Nombre = "Federico García Lorca" }
        );
        #endregion

        #region datos semillas de 9 carreras
        modelBuilder.Entity<Carrera>().HasData(
            new Carrera { Id = 1, Nombre = "Profesorado de Educación Inicial" },
            new Carrera { Id = 2, Nombre = "Profesorado de Educ. Secundaria en Cs de la Administración" },
            new Carrera { Id = 3, Nombre = "Profesorado de Educ. Secundaria en Economía" },
            new Carrera { Id = 4, Nombre = "Profesorado de Educación Tecnológica" },
            new Carrera { Id = 5, Nombre = "Técnico Superior en Desarrollo de Software" },
            new Carrera { Id = 6, Nombre = "Técnico Superior en Enfermería" },
            new Carrera { Id = 7, Nombre = "Tecnicatura Superior en Gestión de Energías Renovables" },
            new Carrera { Id = 8, Nombre = "Técnico Superior en Gestión de las Organizaciones" },
            new Carrera { Id = 9, Nombre = "Técnico Superior en Soporte de Infraestructura en Tecnologías de la Información" }
        );
        #endregion

        #region datos semillas de 10 editoriales 
        modelBuilder.Entity<Editorial>().HasData(
            new Editorial { Id = 1, Nombre = "Penguin Random House" },
            new Editorial { Id = 2, Nombre = "HarperCollins" },
            new Editorial { Id = 3, Nombre = "Simon & Schuster" },
            new Editorial { Id = 4, Nombre = "Hachette Livre" },
            new Editorial { Id = 5, Nombre = "Macmillan Publishers" },
            new Editorial { Id = 6, Nombre = "Grupo Planeta" },
            new Editorial { Id = 7, Nombre = "Santillana" },
            new Editorial { Id = 8, Nombre = "Alfaguara" },
            new Editorial { Id = 9, Nombre = "Wiley" },
            new Editorial { Id = 10, Nombre = "Pearson" }
        );
        #endregion

        #region datos semillas de 5 ejemplares
        modelBuilder.Entity<Ejemplar>().HasData(
            new Ejemplar { 
                Id = 1, 
                LibroId = 1, 
                Disponible= true, 
                Estado = EstadoEnum.Excelente },
            new Ejemplar { 
                Id = 2,
                LibroId = 2, 
                Disponible= true, 
                Estado = EstadoEnum.MuyBueno },
            new Ejemplar { 
                Id = 3,
                LibroId = 3, 
                Disponible= true, 
                Estado = EstadoEnum.Bueno },
            new Ejemplar { 
                Id = 4,
                LibroId = 4, 
                Disponible= true, 
                Estado = EstadoEnum.MuyBueno },
            new Ejemplar { 
                Id = 5,
                LibroId = 5, 
                Disponible= true, 
                Estado = EstadoEnum.Excelente
            });
        #endregion

        #region datos semillas de 10 generos
        modelBuilder.Entity<Genero>().HasData(
            new Genero { Id = 1, Nombre = "Ficción" },
            new Genero { Id = 2, Nombre = "No Ficción" },
            new Genero { Id = 3, Nombre = "Ciencia Ficción" },
            new Genero { Id = 4, Nombre = "Fantasia" },
            new Genero { Id = 5, Nombre = "Misterio" },
            new Genero { Id = 6, Nombre = "Romance" },
            new Genero { Id = 7, Nombre = "Terror" },
            new Genero { Id = 8, Nombre = "Historia" },
            new Genero { Id = 9, Nombre = "Biografía" },
            new Genero { Id = 10, Nombre = "Poesía" }
        );
        #endregion

        #region datos semillas de 10 libros
        modelBuilder.Entity<Libro>().HasData(
            new Libro { 
                Id = 1, 
                Titulo = "Cien Años de Soledad", 
                Descripcion = "Novela emblemática del realismo mágico", 
                EditorialId = 1, 
                Paginas = 417, 
                AnioPublicacion = 1967, 
                Portada = "", 
                Sinopsis = "La historia de la familia Buendía en el pueblo ficticio de Macondo." },
            new Libro { 
                Id = 2, 
                Titulo = "La Casa de los Espíritus", 
                Descripcion = "Novela que mezcla lo real y lo fantástico", 
                EditorialId = 2, 
                Paginas = 448, 
                AnioPublicacion = 1982, 
                Portada = "", 
                Sinopsis = "La saga de la familia Trueba a lo largo de varias generaciones." },
            new Libro { 
                Id = 3, 
                Titulo = "La Ciudad y los Perros", 
                Descripcion = "Novela sobre la vida en un colegio militar", 
                EditorialId = 3, 
                Paginas = 320, 
                AnioPublicacion = 1963, 
                Portada = "", 
                Sinopsis = "Las experiencias de un grupo de cadetes en un colegio militar en Lima." },
            new Libro { 
                Id = 4, 
                Titulo = "Ficciones", 
                Descripcion = "Colección de cuentos fantásticos y filosóficos", 
                EditorialId = 4, 
                Paginas = 224, 
                AnioPublicacion = 1944, 
                Portada = "", 
                Sinopsis = "Una serie de relatos que exploran temas como la realidad y la identidad." },
            new Libro { 
                Id = 5, 
                Titulo = "Veinte Poemas de Amor y una Canción Desesperada", 
                Descripcion = "Colección de poemas románticos", 
                EditorialId = 5, 
                Paginas = 80, 
                AnioPublicacion = 1924, 
                Portada = "", 
                Sinopsis = "Poemas que expresan el amor y la pasión." },
            new Libro { 
                Id = 6, 
                Titulo = "Rayuela", 
                Descripcion = "Novela experimental y vanguardista", 
                EditorialId = 6, 
                Paginas = 576, 
                AnioPublicacion = 1963, 
                Portada = "", 
                Sinopsis = "La historia de Horacio Oliveira y su búsqueda de sentido en la vida." },
            new Libro { 
                Id = 7, 
                Titulo = "Como Agua para Chocolate", 
                Descripcion = "Novela que mezcla la cocina y el amor", 
                EditorialId = 7, 
                Paginas = 256, 
                AnioPublicacion = 1989, 
                Portada = "", 
                Sinopsis = "La historia de Tita y su amor prohibido." },
            new Libro { 
                Id = 8, 
                Titulo = "La Sombra del Viento", 
                Descripcion = "Novela de misterio y aventura", 
                EditorialId = 8, 
                Paginas = 576, 
                AnioPublicacion = 2001, 
                Portada = "", 
                Sinopsis = "La historia de Daniel y su búsqueda del autor Julián Carax." },
            new Libro { 
                Id = 9, 
                Titulo = "Don Quijote de la Mancha", 
                Descripcion = "Novela clásica de la literatura española", 
                EditorialId = 9, 
                Paginas = 863, 
                AnioPublicacion = 1605, 
                Portada = "", 
                Sinopsis = "Las aventuras del ingenioso hidalgo Don Quijote y su fiel escudero Sancho Panza." },
            new Libro { 
                Id = 10, 
                Titulo = "La Casa de Bernarda Alba", 
                Descripcion = "Obra de teatro sobre la opresión y el deseo", 
                EditorialId = 10, 
                Paginas = 96, 
                AnioPublicacion = 1936, 
                Portada = "", 
                Sinopsis = "La historia de Bernarda Alba y sus cinco hijas en una casa dominada por la represión." }
        );
        #endregion

        # region datos semillas de 6 libroautor
        modelBuilder.Entity<LibroAutor>().HasData(
            new LibroAutor { Id = 1, LibroId = 1, AutorId = 1 },
            new LibroAutor { Id = 2, LibroId = 2, AutorId = 2 },
            new LibroAutor { Id = 3, LibroId = 3, AutorId = 3 },
            new LibroAutor { Id = 4, LibroId = 4, AutorId = 4 },
            new LibroAutor { Id = 5, LibroId = 5, AutorId = 5 },
            new LibroAutor { Id = 6, LibroId = 6, AutorId = 6 }
        );
        #endregion

        #region datos semillas de 6 librogenero
        modelBuilder.Entity<LibroGenero>().HasData(
            new LibroGenero { Id = 1, LibroId = 1, GeneroId = 1 },
            new LibroGenero { Id = 2, LibroId = 2, GeneroId = 1 },
            new LibroGenero { Id = 3, LibroId = 3, GeneroId = 1 },
            new LibroGenero { Id = 4, LibroId = 4, GeneroId = 4 },
            new LibroGenero { Id = 5, LibroId = 5, GeneroId = 6 },
            new LibroGenero { Id = 6, LibroId = 6, GeneroId = 4 }
        );

        #endregion

        #region datos semillas de 6 prestamos
        modelBuilder.Entity<Prestamo>().HasData(
        new Prestamo
        {
            Id = 1,
            UsuarioId = 2,
            EjemplarId = 2,
            FechaPrestamo = DateTime.Now,
            FechaDevolucion = DateTime.Now.AddDays(14)
        },
        new Prestamo
        {
            Id = 2,
            UsuarioId = 3,
            EjemplarId = 3,
            FechaPrestamo = DateTime.Now,
            FechaDevolucion = DateTime.Now.AddDays(14)
        },
        new Prestamo
        {
            Id = 3,
            UsuarioId = 4,
            EjemplarId = 4,
            FechaPrestamo = DateTime.Now,
            FechaDevolucion = DateTime.Now.AddDays(14)
        },
        new Prestamo
        {
            Id = 4,
            UsuarioId = 5,
            EjemplarId = 5,
            FechaPrestamo = DateTime.Now,
            FechaDevolucion = DateTime.Now.AddDays(14)
        },
        new Prestamo
        {
            Id = 5,
            UsuarioId = 1,
            EjemplarId = 1,
            FechaPrestamo = DateTime.Now,
            FechaDevolucion = DateTime.Now.AddDays(14)
        },
        new Prestamo
        {
            Id = 6,
            UsuarioId = 6,
            EjemplarId = 1,
            FechaPrestamo = DateTime.Now,
            FechaDevolucion = DateTime.Now.AddDays(14)
        });
        #endregion

        #region datos semillas de 10 usuario
        modelBuilder.Entity<Usuario>().HasData(
            new Usuario { 
                Id = 1, 
                Nombre = "Juan Pérez", 
                Email = "juanperez@gmail.com", 
                Password = "password123", 
                TipoRol = TipoRolEnum.Alumno, 
                Dni = "12345678", 
                Domicilio = "Calle Falsa 123", 
                Telefono = "555-1234", 
                Observacion = "" },
            new Usuario { 
                Id = 2, 
                Nombre = "María Gómez", 
                Email = "mariagomez@gmail.com", 
                Password = "password123", 
                TipoRol = TipoRolEnum.Alumno, 
                Dni = "87654321", 
                Domicilio = "Avenida Siempre Viva 456", 
                Telefono = "555-5678", 
                Observacion = "" },
            new Usuario { 
                Id = 3, 
                Nombre = "Carlos Rodríguez", 
                Email = "carlosrodriguez@gmail.com", 
                Password = "password123", 
                TipoRol = TipoRolEnum.Bibliotecario, 
                Dni = "11223344", 
                Domicilio = "Boulevard Central 789", 
                Telefono = "555-9012", 
                Observacion = "" },
            new Usuario { 
                Id = 4, 
                Nombre = "Ana Martínez", 
                Email = "martinezana@gmail.com", 
                Password = "password123", 
                TipoRol = TipoRolEnum.Alumno, 
                Dni = "44332211", 
                Domicilio = "Plaza Mayor 101", 
                Telefono = "555-3456", 
                Observacion = "" },
            new Usuario { 
                Id = 5, 
                Nombre = "Luis Fernández", 
                Email = "luisfernandez@gmail.com", 
                Password = "password123", 
                TipoRol = TipoRolEnum.Bibliotecario, 
                Dni = "55667788", 
                Domicilio = "Calle del Sol 202", 
                Telefono = "555-7890", 
                Observacion = "" },
            new Usuario { 
                Id = 6, 
                Nombre = "Sofía López", 
                Email = "sofialopez@gmail.com", 
                Password = "password123", 
                TipoRol = TipoRolEnum.Alumno, 
                Dni = "99887766", 
                Domicilio = "Avenida de la Luna 303", 
                Telefono = "555-2345", 
                Observacion = "" },
            new Usuario { 
                Id = 7, 
                Nombre = "Miguel Sánchez", 
                Email = "miguelsanchez@gmail.com", 
                Password = "password123", 
                TipoRol = TipoRolEnum.Alumno, 
                Dni = "66778899", 
                Domicilio = "Calle de las Flores 404", 
                Telefono = "555-6789", 
                Observacion = "" },
            new Usuario { 
                Id = 8, 
                Nombre = "Laura Ramírez", 
                Email = "ramirezlaura@gmail.com", 
                Password = "password123", 
                TipoRol = TipoRolEnum.Bibliotecario, 
                Dni = "33445566", 
                Domicilio = "Avenida del Río 505", 
                Telefono = "555-0123", 
                Observacion = "" },
            new Usuario { 
                Id = 9, 
                Nombre = "Diego Torres",
                Email = "torresdiego@gmail.com", 
                Password = "password123", 
                TipoRol = TipoRolEnum.Alumno, 
                Dni = "22113344", 
                Domicilio = "Plaza de la Ciudad 606", 
                Telefono = "555-4567", 
                Observacion = "" },
            new Usuario { 
                Id = 10, 
                Nombre = "Elena Ruiz", 
                Email = "elenaruiz@gmail.com", 
                Password = "password123", 
                TipoRol = TipoRolEnum.Bibliotecario, 
                Dni = "77889900", 
                Domicilio = "Calle del Mercado 707", 
                Telefono = "555-8901", 
                Observacion = "" }
            );
        #endregion

        #region datos semillas de 10 usuariocarrera
        modelBuilder.Entity<UsuarioCarrera>().HasData(
            new UsuarioCarrera { Id = 1, UsuarioId = 1, CarreraId = 1 },
            new UsuarioCarrera { Id = 2, UsuarioId = 2, CarreraId = 2 },
            new UsuarioCarrera { Id = 3, UsuarioId = 3, CarreraId = 3 },
            new UsuarioCarrera { Id = 4, UsuarioId = 4, CarreraId = 4 },
            new UsuarioCarrera { Id = 5, UsuarioId = 5, CarreraId = 5 },
            new UsuarioCarrera { Id = 6, UsuarioId = 6, CarreraId = 6 },
            new UsuarioCarrera { Id = 7, UsuarioId = 7, CarreraId = 7 },
            new UsuarioCarrera { Id = 8, UsuarioId = 8, CarreraId = 8 },
            new UsuarioCarrera { Id = 9, UsuarioId = 9, CarreraId = 9 },
            new UsuarioCarrera { Id = 10, UsuarioId = 10, CarreraId = 1 }
        );
        #endregion

        //configuramos los query filters para que no trigan los registros marcados como eliminados. Son los mecanimos por el cual se indica que un registro esta eliminado sin borrarlo fisicamente de la base de datos.
        modelBuilder.Entity<Autor>().HasQueryFilter(a => !a.IsDeleted);
        modelBuilder.Entity<Carrera>().HasQueryFilter(c => !c.IsDeleted);
        modelBuilder.Entity<Editorial>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Ejemplar>().HasQueryFilter(ej => !ej.IsDeleted);
        modelBuilder.Entity<Genero>().HasQueryFilter(g => !g.IsDeleted);
        modelBuilder.Entity<Libro>().HasQueryFilter(l => !l.IsDeleted);
        modelBuilder.Entity<LibroAutor>().HasQueryFilter(la => !la.IsDeleted);
        modelBuilder.Entity<LibroGenero>().HasQueryFilter(lg => !lg.IsDeleted);
        modelBuilder.Entity<Prestamo>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<Usuario>().HasQueryFilter(u => !u.IsDeleted);
        modelBuilder.Entity<UsuarioCarrera>().HasQueryFilter(uc => !uc.IsDeleted);

    }
}

