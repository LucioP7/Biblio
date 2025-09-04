using Microsoft.EntityFrameworkCore;
using Service.Enums;
using Service.Models;

namespace Backend.DataContext
{
    public class BiblioContext : DbContext
    {
        public BiblioContext()
        {
        }
        public BiblioContext(DbContextOptions<BiblioContext> options) : base(options)
        {
        }

        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Autor> Autores { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<LibroAutor> LibroAutores { get; set; }
        public virtual DbSet<LibroGenero> LibroGeneros { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Editorial> Editoriales { get; set; }
        public virtual DbSet<Ejemplar> Ejemplares { get; set; }
        public virtual DbSet<UsuarioCarrera> UsuarioCarreras { get; set; }

        //onConfiguring method to set the connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                    .AddEnvironmentVariables()
                                    .Build();
                var connectionString = configuration.GetConnectionString("mysqlRemoto");
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // datos semillas de 10 autores
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

            //datos semillas de 10 generos
            modelBuilder.Entity<Genero>().HasData(
                new Genero { Id = 1, Nombre = "Novela" },
                new Genero { Id = 2, Nombre = "Poesía" },
                new Genero { Id = 3, Nombre = "Cuento" },
                new Genero { Id = 4, Nombre = "Ensayo" },
                new Genero { Id = 5, Nombre = "Teatro" },
                new Genero { Id = 6, Nombre = "Fantasía" },
                new Genero { Id = 7, Nombre = "Ciencia Ficción" },
                new Genero { Id = 8, Nombre = "Misterio" },
                new Genero { Id = 9, Nombre = "Romance" },
                new Genero { Id = 10, Nombre = "Aventura" }
            );

            // datos semillas de 10 editoriales
            modelBuilder.Entity<Editorial>().HasData(
                new Editorial { Id = 1, Nombre = "Penguin Random House" },
                new Editorial { Id = 2, Nombre = "HarperCollins" },
                new Editorial { Id = 3, Nombre = "Simon & Schuster" },
                new Editorial { Id = 4, Nombre = "Hachette Livre" },
                new Editorial { Id = 5, Nombre = "Macmillan Publishers" },
                new Editorial { Id = 6, Nombre = "Scholastic" },
                new Editorial { Id = 7, Nombre = "Bloomsbury" },
                new Editorial { Id = 8, Nombre = "Oxford University Press" },
                new Editorial { Id = 9, Nombre = "Cambridge University Press" },
                new Editorial { Id = 10, Nombre = "Wiley" }
            );

            //datos semillas de 10 carreras
            modelBuilder.Entity<Carrera>().HasData(
                new Carrera { Id = 1, Nombre = "Ingeniería en Sistemas" },
                new Carrera { Id = 2, Nombre = "Medicina" },
                new Carrera { Id = 3, Nombre = "Derecho" },
                new Carrera { Id = 4, Nombre = "Arquitectura" },
                new Carrera { Id = 5, Nombre = "Psicología" },
                new Carrera { Id = 6, Nombre = "Administración de Empresas" },
                new Carrera { Id = 7, Nombre = "Contabilidad" },
                new Carrera { Id = 8, Nombre = "Comunicación Social" },
                new Carrera { Id = 9, Nombre = "Educación" },
                new Carrera { Id = 10, Nombre = "Ingeniería Civil" }
            );

            //datos semillas de 10 libros
            modelBuilder.Entity<Libro>().HasData(
                new Libro
                {
                    Id = 1,
                    Titulo = "Cien Años de Soledad",
                    Descripcion = "Novela emblemática del realismo mágico.",
                    EditorialId = 1,
                    Paginas = 417,
                    AnioPublicacion = 1967,
                    Portada = "https://example.com/cien_anos_de_soledad.jpg",
                    Sinopsis = "La historia de la familia Buendía a lo largo de varias generaciones en el pueblo ficticio de Macondo."
                },
                new Libro
                {
                    Id = 2,
                    Titulo = "La Casa de los Espíritus",
                    Descripcion = "Novela que mezcla lo real con lo sobrenatural.",
                    EditorialId = 2,
                    Paginas = 448,
                    AnioPublicacion = 1982,
                    Portada = "https://example.com/la_casa_de_los_espiritus.jpg",
                    Sinopsis = "Relata la saga de la familia Trueba, explorando temas de amor, política y destino."
                },
                new Libro
                {
                    Id = 3,
                    Titulo = "La Ciudad y los Perros",
                    Descripcion = "Novela que critica la sociedad peruana.",
                    EditorialId = 3,
                    Paginas = 320,
                    AnioPublicacion = 1963,
                    Portada = "https://example.com/la_ciudad_y_los_perros.jpg",
                    Sinopsis = "Ambientada en un colegio militar, aborda temas de violencia, poder y corrupción."
                },
                new Libro
                {
                    Id = 4,
                    Titulo = "Ficciones",
                    Descripcion = "Colección de cuentos filosóficos y metafísicos.",
                    EditorialId = 4,
                    Paginas = 224,
                    AnioPublicacion = 1944,
                    Portada = "https://example.com/ficciones.jpg",
                    Sinopsis = "Una serie de relatos que exploran conceptos como el infinito, los laberintos y la realidad."
                },
                new Libro
                {
                    Id = 5,
                    Titulo = "Veinte Poemas de Amor y una Canción Desesperada",
                    Descripcion = "Antología de poesía romántica.",
                    EditorialId = 5,
                    Paginas = 100,
                    AnioPublicacion = 1924,
                    Portada = "https://example.com/veinte_poemas_de_amor.jpg",
                    Sinopsis = "Una colección de poemas que expresan el amor y la pasión con una intensidad única."
                },
                new Libro
                {
                    Id = 6,
                    Titulo = "Rayuela",
                    Descripcion = "Novela experimental y vanguardista.",
                    EditorialId = 6,
                    Paginas = 576,
                    AnioPublicacion = 1963,
                    Portada = "https://example.com/rayuela.jpg",
                    Sinopsis = "La historia de Horacio Oliveira y su búsqueda de sentido en la vida a través de una estructura narrativa no lineal."
                },
                new Libro
                {
                    Id = 7,
                    Titulo = "Como Agua para Chocolate",
                    Descripcion = "Novela que combina romance y realismo mágico.",
                    EditorialId = 7,
                    Paginas = 256,
                    AnioPublicacion = 1989,
                    Portada = "https://example.com/como_agua_para_chocolate.jpg",
                    Sinopsis = "La historia de Tita, una joven cuya vida está marcada por las tradiciones familiares y su amor prohibido."
                },
                new Libro
                {
                    Id = 8,
                    Titulo = "La Sombra del Caudillo",
                    Descripcion = "Novela política y social.",
                    EditorialId = 8,
                    Paginas = 300,
                    AnioPublicacion = 1929,
                    Portada = "https://example.com/la_sombra_del_caudillo.jpg",
                    Sinopsis = "Una crítica a la dictadura y la corrupción en México a través de la historia de un líder militar."
                },
                new Libro
                {
                    Id = 9,
                    Titulo = "Don Quijote de la Mancha",
                    Descripcion = "Clásico de la literatura española.",
                    EditorialId = 9,
                    Paginas = 863,
                    AnioPublicacion = 1605,
                    Portada = "https://example.com/don_quijote.jpg",
                    Sinopsis = "Las aventuras del ingenioso hidalgo Don Quijote y su fiel escudero Sancho Panza en su lucha contra la injusticia."
                },
                new Libro
                {
                    Id = 10,
                    Titulo = "Bodas de Sangre",
                    Descripcion = "Tragedia teatral basada en hechos reales.",
                    EditorialId = 10,
                    Paginas = 80,
                    AnioPublicacion = 1933,
                    Portada = "https://example.com/bodas_de_sangre.jpg",
                    Sinopsis = "La historia de un amor imposible que termina en tragedia, explorando temas de pasión, destino y honor."
                });

            //datos semillas de 10 ejemplares
            modelBuilder.Entity<Ejemplar>().HasData(
                new Ejemplar { Id = 1, LibroId = 1, Disponible = true, Estado = EstadoEnum.MuyBueno },
                new Ejemplar { Id = 2, LibroId = 1, Disponible = false, Estado = EstadoEnum.Bueno },
                new Ejemplar { Id = 3, LibroId = 2, Disponible = true, Estado = EstadoEnum.Malo },
                new Ejemplar { Id = 4, LibroId = 2, Disponible = false, Estado = EstadoEnum.Regular },
                new Ejemplar { Id = 5, LibroId = 3, Disponible = true, Estado = EstadoEnum.Excelente },
                new Ejemplar { Id = 6, LibroId = 4, Disponible = false, Estado = EstadoEnum.MuyBueno },
                new Ejemplar { Id = 7, LibroId = 5, Disponible = true, Estado = EstadoEnum.Bueno },
                new Ejemplar { Id = 8, LibroId = 6, Disponible = false, Estado = EstadoEnum.Malo },
                new Ejemplar { Id = 9, LibroId = 7, Disponible = true, Estado = EstadoEnum.Regular },
                new Ejemplar { Id = 10, LibroId = 8, Disponible = false, Estado = EstadoEnum.Excelente }
            );

            // datos semillas de relacion muchos a muchos entre libros y autores
            modelBuilder.Entity<LibroAutor>().HasData(
                new LibroAutor { Id = 1, LibroId = 1, AutorId = 1 },
                new LibroAutor { Id = 2, LibroId = 2, AutorId = 2 },
                new LibroAutor { Id = 3, LibroId = 3, AutorId = 3 },
                new LibroAutor { Id = 4, LibroId = 4, AutorId = 4 },
                new LibroAutor { Id = 5, LibroId = 5, AutorId = 5 },
                new LibroAutor { Id = 6, LibroId = 6, AutorId = 6 },
                new LibroAutor { Id = 7, LibroId = 7, AutorId = 7 },
                new LibroAutor { Id = 8, LibroId = 8, AutorId = 8 },
                new LibroAutor { Id = 9, LibroId = 9, AutorId = 9 },
                new LibroAutor { Id = 10, LibroId = 10, AutorId = 10 }
            );

            //datos semillas de relacion muchos a muchos entre libros y generos
            modelBuilder.Entity<LibroGenero>().HasData(
                new LibroGenero { Id = 1, LibroId = 1, GeneroId = 1 },
                new LibroGenero { Id = 2, LibroId = 2, GeneroId = 1 },
                new LibroGenero { Id = 3, LibroId = 3, GeneroId = 4 },
                new LibroGenero { Id = 4, LibroId = 4, GeneroId = 3 },
                new LibroGenero { Id = 5, LibroId = 5, GeneroId = 2 },
                new LibroGenero { Id = 6, LibroId = 6, GeneroId = 6 },
                new LibroGenero { Id = 7, LibroId = 7, GeneroId = 1 },
                new LibroGenero { Id = 8, LibroId = 8, GeneroId = 4 },
                new LibroGenero { Id = 9, LibroId = 9, GeneroId = 1 },
                new LibroGenero { Id = 10, LibroId = 10, GeneroId = 5 }
            );

            //datos semillas de 10 usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nombre = "Juan Pérez",
                    Email = "juan.perez@email.com",
                    Password = "123456",
                    TipoRol = TipoRolEnum.Alumno,
                    FechaRegistracion = new DateTime(2023, 1, 10),
                    Dni = "12345678",
                    Domicilio = "Calle Falsa 123",
                    Telefono = "1112345678",
                    Observacion = "",
                    IsDeleted = false
                },
                new Usuario
                {
                    Id = 2,
                    Nombre = "María Gómez",
                    Email = "maria.gomez@email.com",
                    Password = "abcdef",
                    TipoRol = TipoRolEnum.Bibliotecario,
                    FechaRegistracion = new DateTime(2023, 2, 15),
                    Dni = "23456789",
                    Domicilio = "Av. Siempre Viva 742",
                    Telefono = "1123456789",
                    Observacion = "",
                    IsDeleted = false
                },
                new Usuario
                {
                    Id = 3,
                    Nombre = "Carlos López",
                    Email = "carlos.lopez@email.com",
                    Password = "qwerty",
                    TipoRol = TipoRolEnum.Alumno,
                    FechaRegistracion = new DateTime(2023, 3, 20),
                    Dni = "34567890",
                    Domicilio = "Calle 9 de Julio 456",
                    Telefono = "1134567890",
                    Observacion = "",
                    IsDeleted = false
                },
                new Usuario
                {
                    Id = 4,
                    Nombre = "Ana Torres",
                    Email = "ana.torres@email.com",
                    Password = "password",
                    TipoRol = TipoRolEnum.Alumno,
                    FechaRegistracion = new DateTime(2023, 4, 5),
                    Dni = "45678901",
                    Domicilio = "Av. Corrientes 1000",
                    Telefono = "1145678901",
                    Observacion = "",
                    IsDeleted = false
                },
                new Usuario
                {
                    Id = 5,
                    Nombre = "Pedro Sánchez",
                    Email = "pedro.sanchez@email.com",
                    Password = "pedro123",
                    TipoRol = TipoRolEnum.Alumno,
                    FechaRegistracion = new DateTime(2023, 5, 12),
                    Dni = "56789012",
                    Domicilio = "Calle Mitre 321",
                    Telefono = "1156789012",
                    Observacion = "",
                    IsDeleted = false
                },
                new Usuario
                {
                    Id = 6,
                    Nombre = "Lucía Fernández",
                    Email = "lucia.fernandez@email.com",
                    Password = "lucia456",
                    TipoRol = TipoRolEnum.Alumno,
                    FechaRegistracion = new DateTime(2023, 6, 18),
                    Dni = "67890123",
                    Domicilio = "Av. Belgrano 654",
                    Telefono = "1167890123",
                    Observacion = "",
                    IsDeleted = false
                },
                new Usuario
                {
                    Id = 7,
                    Nombre = "Miguel Ramírez",
                    Email = "miguel.ramirez@email.com",
                    Password = "miguel789",
                    TipoRol = TipoRolEnum.Alumno,
                    FechaRegistracion = new DateTime(2023, 7, 22),
                    Dni = "78901234",
                    Domicilio = "Calle San Martín 987",
                    Telefono = "1178901234",
                    Observacion = "",
                    IsDeleted = false
                },
                new Usuario
                {
                    Id = 8,
                    Nombre = "Sofía Herrera",
                    Email = "sofia.herrera@email.com",
                    Password = "sofia321",
                    TipoRol = TipoRolEnum.Alumno,
                    FechaRegistracion = new DateTime(2023, 8, 30),
                    Dni = "89012345",
                    Domicilio = "Av. Rivadavia 1111",
                    Telefono = "1189012345",
                    Observacion = "",
                    IsDeleted = false
                },
                new Usuario
                {
                    Id = 9,
                    Nombre = "Diego Castro",
                    Email = "diego.castro@email.com",
                    Password = "diego654",
                    TipoRol = TipoRolEnum.Alumno,
                    FechaRegistracion = new DateTime(2023, 9, 10),
                    Dni = "90123456",
                    Domicilio = "Calle Moreno 222",
                    Telefono = "1190123456",
                    Observacion = "",
                    IsDeleted = false
                },
                new Usuario
                {
                    Id = 10,
                    Nombre = "Valentina Ruiz",
                    Email = "valentina.ruiz@email.com",
                    Password = "valen987",
                    TipoRol = TipoRolEnum.Alumno,
                    FechaRegistracion = new DateTime(2023, 10, 5),
                    Dni = "01234567",
                    Domicilio = "Av. Santa Fe 333",
                    Telefono = "1201234567",
                    Observacion = "",
                    IsDeleted = false
                });

            //datos semillas de 10 prestamos
            modelBuilder.Entity<Prestamo>().HasData(
                new Prestamo
                {
                    Id = 1,
                    UsuarioId = 1,
                    EjemplarId = 1,
                    FechaPrestamo = new DateTime(2023, 1, 15),
                    FechaDevolucion = new DateTime(2023, 1, 30),
                    IsDeleted = false
                },
                new Prestamo
                {
                    Id = 2,
                    UsuarioId = 2,
                    EjemplarId = 2,
                    FechaPrestamo = new DateTime(2023, 2, 20),
                    FechaDevolucion = new DateTime(2023, 3, 5),
                    IsDeleted = false
                },
                new Prestamo
                {
                    Id = 3,
                    UsuarioId = 3,
                    EjemplarId = 3,
                    FechaPrestamo = new DateTime(2023, 3, 25),
                    FechaDevolucion = new DateTime(2023, 4, 10),
                    IsDeleted = false
                },
                new Prestamo
                {
                    Id = 4,
                    UsuarioId = 4,
                    EjemplarId = 4,
                    FechaPrestamo = new DateTime(2023, 4, 5),
                    FechaDevolucion = new DateTime(2023, 4, 20),
                    IsDeleted = false
                },
                new Prestamo
                {
                    Id = 5,
                    UsuarioId = 5,
                    EjemplarId = 5,
                    FechaPrestamo = new DateTime(2023, 5, 12),
                    FechaDevolucion = new DateTime(2023, 5, 27),
                    IsDeleted = false
                },
                new Prestamo
                {
                    Id = 6,
                    UsuarioId = 6,
                    EjemplarId = 6,
                    FechaPrestamo = new DateTime(2023, 6, 18),
                    FechaDevolucion = new DateTime(2023, 7, 3),
                    IsDeleted = false
                },
                new Prestamo
                {
                    Id = 7,
                    UsuarioId = 7,
                    EjemplarId = 7,
                    FechaPrestamo = new DateTime(2023, 7, 22),
                    FechaDevolucion = new DateTime(2023, 8, 6),
                    IsDeleted = false
                },
                new Prestamo
                {
                    Id = 8,
                    UsuarioId = 8,
                    EjemplarId = 8,
                    FechaPrestamo = new DateTime(2023, 8, 30),
                    FechaDevolucion = new DateTime(2023, 9, 14),
                    IsDeleted = false
                },
                new Prestamo
                {
                    Id = 9,
                    UsuarioId = 9,
                    EjemplarId = 9,
                    FechaPrestamo = new DateTime(2023, 9, 10),
                    FechaDevolucion = new DateTime(2023, 9, 25),
                    IsDeleted = false
                },
                new Prestamo
                {
                    Id = 10,
                    UsuarioId = 10,
                    EjemplarId = 10,
                    FechaPrestamo = new DateTime(2023, 10, 5),
                    FechaDevolucion = new DateTime(2023, 10, 20),
                    IsDeleted = false
                });

            //datos semillas de relacion muchos a muchos entre usuarios y carreras
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
                new UsuarioCarrera { Id = 10, UsuarioId = 10, CarreraId = 10 }
            );

            //configuramos los query filters para que no traigan los registros marcados como eliminados|
            modelBuilder.Entity<Autor>().HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Genero>().HasQueryFilter(g => !g.IsDeleted);
            modelBuilder.Entity<Editorial>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Libro>().HasQueryFilter(l => !l.IsDeleted);
            modelBuilder.Entity<Ejemplar>().HasQueryFilter(ej => !ej.IsDeleted);
            modelBuilder.Entity<Usuario>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Carrera>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Prestamo>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<UsuarioCarrera>().HasQueryFilter(uc => !uc.IsDeleted);
            modelBuilder.Entity<LibroAutor>().HasQueryFilter(la => !la.IsDeleted);
            modelBuilder.Entity<LibroGenero>().HasQueryFilter(lg => !lg.IsDeleted);
        }
    }
}
