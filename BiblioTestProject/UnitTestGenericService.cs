using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTestProject
{
    public class UnitTestGenericService
    {
        [Fact]
        public async Task Test_GetAllAsync_ReturnListOfEntities()
        {
            //test simple
            //arrange contexto
            //act acion
            //assert afirmacion

            var service = new GenericService<Libro>();
            
            var result = await service.GetAllAsync();
            
            Assert.NotNull(result);
            Assert.IsType<List<Libro>>(result);
            Assert.True(result.Count > 0);
        }
    }
}
