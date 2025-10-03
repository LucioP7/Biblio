using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class creacioninicial : Migration
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
                    { 1, false, "Profesorado de Educación Inicial" },
                    { 2, false, "Profesorado de Educ. Secundaria en Cs de la Administración" },
                    { 3, false, "Profesorado de Educ. Secundaria en Economía" },
                    { 4, false, "Profesorado de Educación Tecnológica" },
                    { 5, false, "Técnico Superior en Desarrollo de Software" },
                    { 6, false, "Técnico Superior en Enfermería" },
                    { 7, false, "Tecnicatura Superior en Gestión de Energías Renovables" },
                    { 8, false, "Técnico Superior en Gestión de las Organizaciones" },
                    { 9, false, "Técnico Superior en Soporte de Infraestructura en Tecnologías de la Información" }
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
                    { 6, false, "Grupo Planeta" },
                    { 7, false, "Santillana" },
                    { 8, false, "Alfaguara" },
                    { 9, false, "Wiley" },
                    { 10, false, "Pearson" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "IsDeleted", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Ficción" },
                    { 2, false, "No Ficción" },
                    { 3, false, "Ciencia Ficción" },
                    { 4, false, "Fantasia" },
                    { 5, false, "Misterio" },
                    { 6, false, "Romance" },
                    { 7, false, "Terror" },
                    { 8, false, "Historia" },
                    { 9, false, "Biografía" },
                    { 10, false, "Poesía" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Dni", "Domicilio", "Email", "FechaRegistracion", "IsDeleted", "Nombre", "Observacion", "Password", "Telefono", "TipoRol" },
                values: new object[,]
                {
                    { 1, "12345678", "Calle Falsa 123", "juanperez@gmail.com", new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(509), false, "Juan Pérez", "", "password123", "555-1234", 0 },
                    { 2, "87654321", "Avenida Siempre Viva 456", "mariagomez@gmail.com", new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(513), false, "María Gómez", "", "password123", "555-5678", 0 },
                    { 3, "11223344", "Boulevard Central 789", "carlosrodriguez@gmail.com", new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(515), false, "Carlos Rodríguez", "", "password123", "555-9012", 2 },
                    { 4, "44332211", "Plaza Mayor 101", "martinezana@gmail.com", new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(516), false, "Ana Martínez", "", "password123", "555-3456", 0 },
                    { 5, "55667788", "Calle del Sol 202", "luisfernandez@gmail.com", new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(518), false, "Luis Fernández", "", "password123", "555-7890", 2 },
                    { 6, "99887766", "Avenida de la Luna 303", "sofialopez@gmail.com", new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(519), false, "Sofía López", "", "password123", "555-2345", 0 },
                    { 7, "66778899", "Calle de las Flores 404", "miguelsanchez@gmail.com", new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(520), false, "Miguel Sánchez", "", "password123", "555-6789", 0 },
                    { 8, "33445566", "Avenida del Río 505", "ramirezlaura@gmail.com", new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(522), false, "Laura Ramírez", "", "password123", "555-0123", 2 },
                    { 9, "22113344", "Plaza de la Ciudad 606", "torresdiego@gmail.com", new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(524), false, "Diego Torres", "", "password123", "555-4567", 0 },
                    { 10, "77889900", "Calle del Mercado 707", "elenaruiz@gmail.com", new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(525), false, "Elena Ruiz", "", "password123", "555-8901", 2 }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "Id", "AnioPublicacion", "Descripcion", "EditorialId", "IsDeleted", "Paginas", "Portada", "Sinopsis", "Titulo" },
                values: new object[,]
                {
                    { 1, 1967, "Novela emblemática del realismo mágico", 1, false, 417, "", "La historia de la familia Buendía en el pueblo ficticio de Macondo.", "Cien Años de Soledad" },
                    { 2, 1982, "Novela que mezcla lo real y lo fantástico", 2, false, 448, "", "La saga de la familia Trueba a lo largo de varias generaciones.", "La Casa de los Espíritus" },
                    { 3, 1963, "Novela sobre la vida en un colegio militar", 3, false, 320, "", "Las experiencias de un grupo de cadetes en un colegio militar en Lima.", "La Ciudad y los Perros" },
                    { 4, 1944, "Colección de cuentos fantásticos y filosóficos", 4, false, 224, "", "Una serie de relatos que exploran temas como la realidad y la identidad.", "Ficciones" },
                    { 5, 1924, "Colección de poemas románticos", 5, false, 80, "", "Poemas que expresan el amor y la pasión.", "Veinte Poemas de Amor y una Canción Desesperada" },
                    { 6, 1963, "Novela experimental y vanguardista", 6, false, 576, "", "La historia de Horacio Oliveira y su búsqueda de sentido en la vida.", "Rayuela" },
                    { 7, 1989, "Novela que mezcla la cocina y el amor", 7, false, 256, "", "La historia de Tita y su amor prohibido.", "Como Agua para Chocolate" },
                    { 8, 2001, "Novela de misterio y aventura", 8, false, 576, "", "La historia de Daniel y su búsqueda del autor Julián Carax.", "La Sombra del Viento" },
                    { 9, 1605, "Novela clásica de la literatura española", 9, false, 863, "", "Las aventuras del ingenioso hidalgo Don Quijote y su fiel escudero Sancho Panza.", "Don Quijote de la Mancha" },
                    { 10, 1936, "Obra de teatro sobre la opresión y el deseo", 10, false, 96, "", "La historia de Bernarda Alba y sus cinco hijas en una casa dominada por la represión.", "La Casa de Bernarda Alba" }
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
                    { 10, 1, false, 10 }
                });

            migrationBuilder.InsertData(
                table: "Ejemplares",
                columns: new[] { "Id", "Disponible", "Estado", "IsDeleted", "LibroId" },
                values: new object[,]
                {
                    { 1, true, 0, false, 1 },
                    { 2, true, 1, false, 2 },
                    { 3, true, 2, false, 3 },
                    { 4, true, 1, false, 4 },
                    { 5, true, 0, false, 5 }
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
                    { 6, 6, false, 6 }
                });

            migrationBuilder.InsertData(
                table: "LibroGeneros",
                columns: new[] { "Id", "GeneroId", "IsDeleted", "LibroId" },
                values: new object[,]
                {
                    { 1, 1, false, 1 },
                    { 2, 1, false, 2 },
                    { 3, 1, false, 3 },
                    { 4, 4, false, 4 },
                    { 5, 6, false, 5 },
                    { 6, 4, false, 6 }
                });

            migrationBuilder.InsertData(
                table: "Prestamos",
                columns: new[] { "Id", "EjemplarId", "FechaDevolucion", "FechaPrestamo", "IsDeleted", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2025, 9, 14, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(453), new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(452), false, 2 },
                    { 2, 3, new DateTime(2025, 9, 14, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(464), new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(464), false, 3 },
                    { 3, 4, new DateTime(2025, 9, 14, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(467), new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(466), false, 4 },
                    { 4, 5, new DateTime(2025, 9, 14, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(469), new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(469), false, 5 },
                    { 5, 1, new DateTime(2025, 9, 14, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(472), new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(471), false, 1 },
                    { 6, 1, new DateTime(2025, 9, 14, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(474), new DateTime(2025, 8, 31, 20, 6, 23, 968, DateTimeKind.Local).AddTicks(473), false, 6 }
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
