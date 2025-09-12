using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    //esto es un contrato que deben cumplir todos los servicios genericos
    public interface IUsuarioService: IGenericService<Usuario>
    {
        //esto es una firma, contratos que deben cumplir las clases que implementen esta interfaz
        //metodos asincronos, devuelven una tarea, que al completarse devuelve una lista de T o null, aceptan un filtro opcional, un string que puede ser nulo, para filtrar los resultados
        public Task<Usuario?> GetByEmailAsync(string email);
    }
}
