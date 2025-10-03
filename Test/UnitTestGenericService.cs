using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyModel;
using Service.DTOs;
using Service.Models;
using Service.Services;

namespace Test
{
    public class UnitTestGenericService
    {
        //Test GetAllAsync método del GenericService
        [Fact]
        public async Task Test_GetAllAsync_ReturnsListOfEntities()
        {
            //ARRAGE es el contexto del test. Lo que necesito para correr el test.
            await LoginTest();

            var service = new GenericService<Libro>();

            //ACT. Accion que voy a testear.
            var result = await service.GetAllAsync();

            //ASSERT. Verificacion de que la accion se comporta como espero. Comprobaciones.
            Assert.NotNull(result);
            Assert.IsType<List<Libro>>(result);
            Assert.True(result.Count > 0);
        }

        private async Task LoginTest()
        { 
            var serviceAuth = new AuthService();
            var token = await serviceAuth.Login(new LoginDTO
            {
                Username = "pianettilucio@gmail.com",
                Password = "12345678"
            });
            Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>>>>>>Token: {token}");
        }
        //Test GetAllAsyn método del GenericService con filtro
        [Fact]
        public async Task Test_GetAllAsync_WithFilter()
        {
            //ARRAGE es el contexto del test. Lo que necesito para correr el test.
            await LoginTest();
            var service = new GenericService<Libro>();

            //ACT. Accion que voy a testear.
            var result = await service.GetAllAsync("Amor");

            //ASSERT. Verificacion de que la accion se comporta como espero. Comprobaciones.
            Assert.NotNull(result);
            Assert.IsType<List<Libro>>(result);
            Assert.True(result.Count == 1);
            Assert.Equal("Veinte Poemas de Amor y una Canción Desesperada", result[0].Titulo);
        }

        //Test AddAsync metodo del generic service
        [Fact]
        public async Task Test_AddAsync_AddsEntity()
        {
            await LoginTest();
            //ARRAGE es el contexto del test. Lo que necesito para correr el test.
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
            //ACT. Accion que voy a testear.
            var result = await service.AddAsync(newLibro);
            //ASSERT. Verificacion de que la accion se comporta como espero. Comprobaciones.
            Assert.NotNull(result);
            Assert.IsType<Libro>(result);
            Assert.Equal("Test Libro", result.Titulo);
        }

        //Test DeleteAsync método del generic service
        [Fact]
        public async Task Test_DeleteAsync_DeletesEntity()
        {
            //ARRAGE es el contexto del test. Lo que necesito para correr el test.
            await LoginTest();
            var service = new GenericService<Libro>();
            //Primero , agregamos un libro para asegurarnos de que hay algo que eliminar
            var newLibro = new Libro
            {
                Titulo = "Test Libro to Delete",
                Descripcion = "Descripcion del libro de prueba a eliminar",
                EditorialId = 1,
                Paginas = 100,
                AnioPublicacion = 2024,
                Portada = "portada.jpg",
                Sinopsis = "Sinopsis del libro de prueba a eliminar"
            };
            var addedLibro = await service.AddAsync(newLibro);
            Assert.NotNull(addedLibro);
            //ACT. Accion que voy a testear.
            var result = await service.DeleteAsync(addedLibro.Id);
            //ASSERT. Verificacion de que la accion se comporta como espero. Comprobaciones.
            Assert.True(result);
        }

        //Test Deleteds método del GenericService
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
            Assert.True(result.Count >= 0);
            // Asumiendo que podría haber cero o más entidades eliminadas.
        }

        //Test Update método del GenericService
        [Fact]
        public async Task Test_UpdateAsync_UpdatesEntity()
        {
            //ARRAGE es el contexto del test. Lo que necesito para correr el test.
            await LoginTest();
            var service = new GenericService<Libro>();
            //Primero , agregamos un libro para asegurarnos de que hay algo que actualizar
            var newLibro = new Libro
            {
                Titulo = "Test Libro to Update",
                Descripcion = "Descripcion del libro de prueba a actualizar",
                EditorialId = 1,
                Paginas = 100,
                AnioPublicacion = 2024,
                Portada = "portada.jpg",
                Sinopsis = "Sinopsis del libro de prueba a actualizar"
            };
            var addedLibro = await service.AddAsync(newLibro);
            Assert.NotNull(addedLibro);
            // Modificar algunas propiedades del libro
            addedLibro.Titulo = "Updated Test Libro";
            addedLibro.Paginas = 150;
            //ACT. Accion que voy a testear.
            var result = await service.UpdateAsync(addedLibro);
            //ASSERT. Verificacion de que la accion se comporta como espero. Comprobaciones.
            Assert.NotNull(result);
            Assert.True(result);
        }

        //Test GetByIdAsync método del GenericService
        [Fact]
        public async Task Test_GetByIdAsync_ReturnsEntity()
        {
            //ARRAGE es el contexto del test. Lo que necesito para correr el test.
            await LoginTest();
            var service = new GenericService<Libro>();
            //Primero , agregamos un libro para asegurarnos de que hay algo que obtener por id
            var newLibro = new Libro
            {
                Titulo = "Test Libro to GetById",
                Descripcion = "Descripcion del libro de prueba a obtener por id",
                EditorialId = 1,
                Paginas = 100,
                AnioPublicacion = 2024,
                Portada = "portada.jpg",
                Sinopsis = "Sinopsis del libro de prueba a obtener por id"
            };
            var addedLibro = await service.AddAsync(newLibro);
            Assert.NotNull(addedLibro);
            //ACT. Accion que voy a testear.
            var result = await service.GetByIdAsync(addedLibro.Id);
            //ASSERT. Verificacion de que la accion se comporta como espero. Comprobaciones.
            Assert.NotNull(result);
            Assert.IsType<Libro>(result);
            Assert.Equal(addedLibro.Id, result.Id);
        }
        //Test RestoreAsync método del GenericService
        [Fact]
        public async Task Test_RestoreAsync_RestoresEntity()
        {
            //ARRAGE es el contexto del test. Lo que necesito para correr el test.
            await LoginTest();
            var service = new GenericService<Libro>();
            //Primero , agregamos un libro para asegurarnos de que hay algo que restaurar
            var newLibro = new Libro
            {
                Titulo = "Test Libro to Restore",
                Descripcion = "Descripcion del libro de prueba a restaurar",
                EditorialId = 1,
                Paginas = 100,
                AnioPublicacion = 2024,
                Portada = "portada.jpg",
                Sinopsis = "Sinopsis del libro de prueba a restaurar"
            };
            var addedLibro = await service.AddAsync(newLibro);
            Assert.NotNull(addedLibro);
            // Primero eliminamos el libro
            var deleteResult = await service.DeleteAsync(addedLibro.Id);
            Assert.True(deleteResult);
            //ACT. Accion que voy a testear.
            var restoreResult = await service.RestoreAsync(addedLibro.Id);
            //ASSERT. Verificacion de que la accion se comporta como espero. Comprobaciones.
            Assert.True(restoreResult);
        }
    }
}

