using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    //esto es un contrato que deben cumplir todos los servicios genericos
    public interface IGenericService<T> where T : class
    {
        //esto es una firma, contratos que deben cumplir las clases que implementen esta interfaz
        //metodos asincronos, devuelven una tarea, que al completarse devuelve una lista de T o null, aceptan un filtro opcional, un string que puede ser nulo, para filtrar los resultados
        public Task<List<T>?> GetAllAsync(string? filtro);
        public Task<List<T>?> GetAllDeletedsAsync(string? filtro);
        public Task<T?> GetByIdAsync(int id);
        public Task<T?> AddAsync(T? entity);
        public Task<bool> UpdateAsync(T? entity);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> RestoreAsync(int id);
    }
}
