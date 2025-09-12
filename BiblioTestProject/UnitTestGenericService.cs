using Microsoft.Extensions.Configuration;
using Service.Models;
using Service.Services;
using System.Text;
using System.Text.Json;

namespace BiblioTestProject
{
    public class UnitTestGenericService
    {
        // Test GetAllAsync method of GenericService
        [Fact]
        public async Task Test_GetAlAsync_ReturnListOfEntities()
        {
            //Arrange

            await LoginTest();
            //Act 
            var service = new GenericService<Libro>();
            var result = await service.GetAllAsync();


            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Libro>>(result);
            Assert.True(result.Count > 0);
        }

        private async Task LoginTest()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var serviceAuth = new AuthService();
            var token = await serviceAuth.Login(new Login
            {
                Username = "pianettilucio@gmail.com",
                Password = "12345678"
            });
            GenericService<object>.jwtToken = token;
        }

        [Fact]
        public async Task Test_GetAlAsync_WhitFilter()
        {
            await LoginTest();
            //Arrange
            var service = new GenericService<Libro>();

            //Act 
            var result = await service.GetAllAsync("Cien");

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Libro>>(result);
            Assert.True(result.Count == 1);
            Assert.Equal("Cien Años de Soledad", result[0].Titulo);
        }

        [Fact]
        public async Task Test_AddAsync_ReturnEntity()
        {
            //Arrange
            await LoginTest();
            var service = new GenericService<Libro>();
            var newLibro = new Libro
            {
                Titulo = "Test Libro",
                Descripcion = "Descripcion del libro de prueba",
                EditorialId = 1,
                Paginas = 100,
                AnioPublicacion = 2024,
                Portada = "portada.jpg",
                Sinopsis = "Sinopsis del libro de prueba"
            };
            //Act 
            var result = await service.AddAsync(newLibro);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Libro>(result);
            Assert.Equal("Test Libro", result.Titulo);
        }

        [Fact]
        public async Task Test_DeleteAsync_ReturnTrue()
        {
            //Arrange
            await LoginTest();
            var service = new GenericService<Libro>();
            var newLibro = new Libro
            {
                Titulo = "Test Libro to Delete",
                Descripcion = "Descripcion del libro de prueba",
                EditorialId = 1,
                Paginas = 100,
                AnioPublicacion = 2024,
                Portada = "portada.jpg",
                Sinopsis = "Sinopsis del libro de prueba"
            };
            var addedLibro = await service.AddAsync(newLibro);
            Assert.NotNull(addedLibro);
            //Act 
            var result = await service.DeleteAsync(addedLibro.Id);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Test_GetAllDeletedsAsync_ReturnsListOfDeletedEntities()
        {
            // Arrange
            await LoginTest();
            var service = new GenericService<Libro>();
            // Act
            var result = await service.GetAllDeletedsAsync();
            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Libro>>(result);
            Assert.True(result.Count >= 0); // Assuming there could be zero or more deleted entities
        }

        [Fact]
        public async Task Test_UpdateAsync_ReturnsUpdatedEntity()
        {
            // Arrange
            await LoginTest();
            var service = new GenericService<Libro>();
            var newLibro = new Libro
            {
                Titulo = "Test Libro to Update",
                Descripcion = "Descripcion del libro de prueba",
                EditorialId = 1,
                Paginas = 100,
                AnioPublicacion = 2024,
                Portada = "portada.jpg",
                Sinopsis = "Sinopsis del libro de prueba"
            };
            var addedLibro = await service.AddAsync(newLibro);
            Assert.NotNull(addedLibro);
            // Modify some properties
            addedLibro.Titulo = "Updated Test Libro";
            addedLibro.Paginas = 150;
            // Act
            var result = await service.UpdateAsync(addedLibro);
            // Assert
            Assert.NotNull(result);
            Assert.True(result);

        }

        [Fact]
        public async Task Test_GetByIdAsync_ReturnsEntity()
        {
            // Arrange
            await LoginTest();
            var service = new GenericService<Libro>();
            var newLibro = new Libro
            {
                Titulo = "Test Libro to GetById",
                Descripcion = "Descripcion del libro de prueba",
                EditorialId = 1,
                Paginas = 100,
                AnioPublicacion = 2024,
                Portada = "portada.jpg",
                Sinopsis = "Sinopsis del libro de prueba"
            };
            var addedLibro = await service.AddAsync(newLibro);
            Assert.NotNull(addedLibro);
            // Act
            var result = await service.GetByIdAsync(addedLibro.Id);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Libro>(result);
            Assert.Equal(addedLibro.Id, result.Id);

        }

        [Fact]
        //restore
        public async Task Test_RestoreAsync_ReturnsTrue()
        {
            // Arrange
            await LoginTest();
            var service = new GenericService<Libro>();
            var newLibro = new Libro
            {
                Titulo = "Test Libro to Restore",
                Descripcion = "Descripcion del libro de prueba",
                EditorialId = 1,
                Paginas = 100,
                AnioPublicacion = 2024,
                Portada = "portada.jpg",
                Sinopsis = "Sinopsis del libro de prueba"
            };
            var addedLibro = await service.AddAsync(newLibro);
            Assert.NotNull(addedLibro);
            var deleteResult = await service.DeleteAsync(addedLibro.Id);
            Assert.True(deleteResult);
            // Act
            var restoreResult = await service.RestoreAsync(addedLibro.Id);
            // Assert
            Assert.True(restoreResult);
        }
    }
}