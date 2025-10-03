using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        //Las interfaces son contratos que definimos que va a cumplir nuestra clase. Nos permiten, por injeccion de dependencias, insertarlas en diferentes lugares. Es una forma ordenada de trabajar. 

        //Esto es la firma del método. Su alcance, el valor que devuelve, su denominacion, parentesis y los parametros que recibe. Cada renglon es una firma. Todo es el contrato que asume el generic service si le decimos que implemente esta interfaz. Es la estructura que determina como trabaja el método. 

        public Task<List<T>?> GetAllAsync(string? filtro);
        public Task<List<T>?> GetAllDeletedsAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task<T?> AddAsync(T? entity);
        public Task<bool> UpdateAsync(T? entity);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> RestoreAsync(int id);
    }
}
