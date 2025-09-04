using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoRol = table.Column<int>(type: "int", nullable: false),
                    FechaRegistracion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Dni = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Domicilio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observacion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EditorialId = table.Column<int>(type: "int", nullable: false),
                    Paginas = table.Column<int>(type: "int", nullable: false),
                    AnioPublicacion = table.Column<int>(type: "int", nullable: false),
                    Portada = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sinopsis = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libros_Editoriales_EditorialId",
                        column: x => x.EditorialId,
                        principalTable: "Editoriales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioCarreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CarreraId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioCarreras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioCarreras_Carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioCarreras_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ejemplares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LibroId = table.Column<int>(type: "int", nullable: false),
                    Disponible = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejemplares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ejemplares_Libros_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LibroAutores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LibroId = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroAutores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibroAutores_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroAutores_Libros_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LibroGeneros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LibroId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroGeneros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibroGeneros_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroGeneros_Libros_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EjemplarId = table.Column<int>(type: "int", nullable: false),
                    FechaPrestamo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamos_Ejemplares_EjemplarId",
                        column: x => x.EjemplarId,
                        principalTable: "Ejemplares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "Id", "IsDeleted", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Gabriel García Márquez" },
                    { 2, false, "Isabel Allende" },
                    { 3, false, "Mario Vargas Llosa" },
                    { 4, false, "Jorge Luis Borges" },
                    { 5, false, "Pablo Neruda" },
                    { 6, false, "Julio Cortázar" },
                    { 7, false, "Laura Esquivel" },
                    { 8, false, "Carlos Fuentes" },
                    { 9, false, "Miguel de Cervantes" },
                    { 10, false, "Federico García Lorca" }
                });

            migrationBuilder.InsertData(
                table: "Carreras",
                columns: new[] { "Id", "IsDeleted", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Ingeniería en Sistemas" },
                    { 2, false, "Medicina" },
                    { 3, false, "Derecho" },
                    { 4, false, "Arquitectura" },
                    { 5, false, "Psicología" },
                    { 6, false, "Administración de Empresas" },
                    { 7, false, "Contabilidad" },
                    { 8, false, "Comunicación Social" },
                    { 9, false, "Educación" },
                    { 10, false, "Ingeniería Civil" }
                });

            migrationBuilder.InsertData(
                table: "Editoriales",
                columns: new[] { "Id", "IsDeleted", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Penguin Random House" },
                    { 2, false, "HarperCollins" },
                    { 3, false, "Simon & Schuster" },
                    { 4, false, "Hachette Livre" },
                    { 5, false, "Macmillan Publishers" },
                    { 6, false, "Scholastic" },
                    { 7, false, "Bloomsbury" },
                    { 8, false, "Oxford University Press" },
                    { 9, false, "Cambridge University Press" },
                    { 10, false, "Wiley" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "IsDeleted", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Novela" },
                    { 2, false, "Poesía" },
                    { 3, false, "Cuento" },
                    { 4, false, "Ensayo" },
                    { 5, false, "Teatro" },
                    { 6, false, "Fantasía" },
                    { 7, false, "Ciencia Ficción" },
                    { 8, false, "Misterio" },
                    { 9, false, "Romance" },
                    { 10, false, "Aventura" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Dni", "Domicilio", "Email", "FechaRegistracion", "IsDeleted", "Nombre", "Observacion", "Password", "Telefono", "TipoRol" },
                values: new object[,]
                {
                    { 1, "12345678", "Calle Falsa 123", "juan.perez@email.com", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Juan Pérez", "", "123456", "1112345678", 0 },
                    { 2, "23456789", "Av. Siempre Viva 742", "maria.gomez@email.com", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "María Gómez", "", "abcdef", "1123456789", 2 },
                    { 3, "34567890", "Calle 9 de Julio 456", "carlos.lopez@email.com", new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Carlos López", "", "qwerty", "1134567890", 0 },
                    { 4, "45678901", "Av. Corrientes 1000", "ana.torres@email.com", new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ana Torres", "", "password", "1145678901", 0 },
                    { 5, "56789012", "Calle Mitre 321", "pedro.sanchez@email.com", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Pedro Sánchez", "", "pedro123", "1156789012", 0 },
                    { 6, "67890123", "Av. Belgrano 654", "lucia.fernandez@email.com", new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Lucía Fernández", "", "lucia456", "1167890123", 0 },
                    { 7, "78901234", "Calle San Martín 987", "miguel.ramirez@email.com", new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Miguel Ramírez", "", "miguel789", "1178901234", 0 },
                    { 8, "89012345", "Av. Rivadavia 1111", "sofia.herrera@email.com", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Sofía Herrera", "", "sofia321", "1189012345", 0 },
                    { 9, "90123456", "Calle Moreno 222", "diego.castro@email.com", new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Diego Castro", "", "diego654", "1190123456", 0 },
                    { 10, "01234567", "Av. Santa Fe 333", "valentina.ruiz@email.com", new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Valentina Ruiz", "", "valen987", "1201234567", 0 }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "Id", "AnioPublicacion", "Descripcion", "EditorialId", "IsDeleted", "Paginas", "Portada", "Sinopsis", "Titulo" },
                values: new object[,]
                {
                    { 1, 1967, "Novela emblemática del realismo mágico.", 1, false, 417, "https://example.com/cien_anos_de_soledad.jpg", "La historia de la familia Buendía a lo largo de varias generaciones en el pueblo ficticio de Macondo.", "Cien Años de Soledad" },
                    { 2, 1982, "Novela que mezcla lo real con lo sobrenatural.", 2, false, 448, "https://example.com/la_casa_de_los_espiritus.jpg", "Relata la saga de la familia Trueba, explorando temas de amor, política y destino.", "La Casa de los Espíritus" },
                    { 3, 1963, "Novela que critica la sociedad peruana.", 3, false, 320, "https://example.com/la_ciudad_y_los_perros.jpg", "Ambientada en un colegio militar, aborda temas de violencia, poder y corrupción.", "La Ciudad y los Perros" },
                    { 4, 1944, "Colección de cuentos filosóficos y metafísicos.", 4, false, 224, "https://example.com/ficciones.jpg", "Una serie de relatos que exploran conceptos como el infinito, los laberintos y la realidad.", "Ficciones" },
                    { 5, 1924, "Antología de poesía romántica.", 5, false, 100, "https://example.com/veinte_poemas_de_amor.jpg", "Una colección de poemas que expresan el amor y la pasión con una intensidad única.", "Veinte Poemas de Amor y una Canción Desesperada" },
                    { 6, 1963, "Novela experimental y vanguardista.", 6, false, 576, "https://example.com/rayuela.jpg", "La historia de Horacio Oliveira y su búsqueda de sentido en la vida a través de una estructura narrativa no lineal.", "Rayuela" },
                    { 7, 1989, "Novela que combina romance y realismo mágico.", 7, false, 256, "https://example.com/como_agua_para_chocolate.jpg", "La historia de Tita, una joven cuya vida está marcada por las tradiciones familiares y su amor prohibido.", "Como Agua para Chocolate" },
                    { 8, 1929, "Novela política y social.", 8, false, 300, "https://example.com/la_sombra_del_caudillo.jpg", "Una crítica a la dictadura y la corrupción en México a través de la historia de un líder militar.", "La Sombra del Caudillo" },
                    { 9, 1605, "Clásico de la literatura española.", 9, false, 863, "https://example.com/don_quijote.jpg", "Las aventuras del ingenioso hidalgo Don Quijote y su fiel escudero Sancho Panza en su lucha contra la injusticia.", "Don Quijote de la Mancha" },
                    { 10, 1933, "Tragedia teatral basada en hechos reales.", 10, false, 80, "https://example.com/bodas_de_sangre.jpg", "La historia de un amor imposible que termina en tragedia, explorando temas de pasión, destino y honor.", "Bodas de Sangre" }
                });

            migrationBuilder.InsertData(
                table: "UsuarioCarreras",
                columns: new[] { "Id", "CarreraId", "IsDeleted", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, false, 1 },
                    { 2, 2, false, 2 },
                    { 3, 3, false, 3 },
                    { 4, 4, false, 4 },
                    { 5, 5, false, 5 },
                    { 6, 6, false, 6 },
                    { 7, 7, false, 7 },
                    { 8, 8, false, 8 },
                    { 9, 9, false, 9 },
                    { 10, 10, false, 10 }
                });

            migrationBuilder.InsertData(
                table: "Ejemplares",
                columns: new[] { "Id", "Disponible", "Estado", "IsDeleted", "LibroId" },
                values: new object[,]
                {
                    { 1, true, 1, false, 1 },
                    { 2, false, 2, false, 1 },
                    { 3, true, 4, false, 2 },
                    { 4, false, 3, false, 2 },
                    { 5, true, 0, false, 3 },
                    { 6, false, 1, false, 4 },
                    { 7, true, 2, false, 5 },
                    { 8, false, 4, false, 6 },
                    { 9, true, 3, false, 7 },
                    { 10, false, 0, false, 8 }
                });

            migrationBuilder.InsertData(
                table: "LibroAutores",
                columns: new[] { "Id", "AutorId", "IsDeleted", "LibroId" },
                values: new object[,]
                {
                    { 1, 1, false, 1 },
                    { 2, 2, false, 2 },
                    { 3, 3, false, 3 },
                    { 4, 4, false, 4 },
                    { 5, 5, false, 5 },
                    { 6, 6, false, 6 },
                    { 7, 7, false, 7 },
                    { 8, 8, false, 8 },
                    { 9, 9, false, 9 },
                    { 10, 10, false, 10 }
                });

            migrationBuilder.InsertData(
                table: "LibroGeneros",
                columns: new[] { "Id", "GeneroId", "IsDeleted", "LibroId" },
                values: new object[,]
                {
                    { 1, 1, false, 1 },
                    { 2, 1, false, 2 },
                    { 3, 4, false, 3 },
                    { 4, 3, false, 4 },
                    { 5, 2, false, 5 },
                    { 6, 6, false, 6 },
                    { 7, 1, false, 7 },
                    { 8, 4, false, 8 },
                    { 9, 1, false, 9 },
                    { 10, 5, false, 10 }
                });

            migrationBuilder.InsertData(
                table: "Prestamos",
                columns: new[] { "Id", "EjemplarId", "FechaDevolucion", "FechaPrestamo", "IsDeleted", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1 },
                    { 2, 2, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2 },
                    { 3, 3, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3 },
                    { 4, 4, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4 },
                    { 5, 5, new DateTime(2023, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5 },
                    { 6, 6, new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6 },
                    { 7, 7, new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 7 },
                    { 8, 8, new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 8 },
                    { 9, 9, new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 9 },
                    { 10, 10, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ejemplares_LibroId",
                table: "Ejemplares",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_LibroAutores_AutorId",
                table: "LibroAutores",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_LibroAutores_LibroId",
                table: "LibroAutores",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_LibroGeneros_GeneroId",
                table: "LibroGeneros",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_LibroGeneros_LibroId",
                table: "LibroGeneros",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_EditorialId",
                table: "Libros",
                column: "EditorialId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_EjemplarId",
                table: "Prestamos",
                column: "EjemplarId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_UsuarioId",
                table: "Prestamos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCarreras_CarreraId",
                table: "UsuarioCarreras",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCarreras_UsuarioId",
                table: "UsuarioCarreras",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibroAutores");

            migrationBuilder.DropTable(
                name: "LibroGeneros");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "UsuarioCarreras");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Ejemplares");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Editoriales");
        }
    }
}
