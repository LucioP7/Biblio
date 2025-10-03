using Service.Interfaces;
using Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        //El cliente http nos permite hacer peticiones http a una api, como get, post, put, delete.
        //Lo puede instanciar directamente o recibirlo por inyeccion de dependencia.
        protected readonly HttpClient _httpClient;
        //Los generic service necesitan impactar sobre un endpoint. Es un punto de entrada de nuestra api. 
        protected readonly string _endpoint;
        //Esto es para serializar y deserializar objetos json. Nos permite convertir objetos a json y viceversa. 
        protected readonly JsonSerializerOptions _options;
        public static string? jwtToken = string.Empty;

        public GenericService(HttpClient? httpClient = null)
        {
            //Esto es un operador de fusión nula. Si httpClient es null, se crea una nueva instancia de HttpClient. El operador ?? verifica si el operando de la izquierda es null; si lo es, devuelve el operando de la derecha.
            _httpClient = httpClient?? new HttpClient();
            //Esto es para que no importe si las propiedades del json vienen en mayuscula o minuscula.  
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _endpoint = Properties.Resources.UrlApi+ApiEndpoints.GetEndpoint(typeof(T).Name);
        }
        protected void SetAuthorizationHeader()
        {
            if (!string.IsNullOrEmpty(GenericService<object>.jwtToken))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GenericService<object>.jwtToken);
            else
                throw new ArgumentException("Error Token no definido", nameof(GenericService<object>.jwtToken));
        }
        public async Task<T?> AddAsync(T? entity)
        {
            SetAuthorizationHeader();
            var response = await _httpClient.PostAsJsonAsync(_endpoint, entity);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al agregar el dato: {response.StatusCode} - {content}");
            }
            return JsonSerializer.Deserialize<T>(content, _options);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            SetAuthorizationHeader();
            var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al eliminar el dato: {response.StatusCode}");
            }
            return response.IsSuccessStatusCode;
        }

        public async Task<List<T>?> GetAllAsync(string? filtro = "")
        {
            SetAuthorizationHeader();
            var response= await _httpClient.GetAsync($"{_endpoint}?filtro={filtro}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<T>>(content, _options);
               
            }
            else
            {
                throw new Exception("Error al obtener los datos");
            }
        }

        public async Task<List<T>?> GetAllDeletedsAsync()
        {
            SetAuthorizationHeader();
            var response = await _httpClient.GetAsync($"{_endpoint}/deleteds");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<List<T>>(content, _options);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            SetAuthorizationHeader();
            var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<T>(content, _options);
        }

        public async Task<bool> RestoreAsync(int id)
        {
            SetAuthorizationHeader();
            var response = await _httpClient.PutAsync($"{_endpoint}/restore/{id}", null);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al restaurar el dato: {response.StatusCode}");
            }
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(T? entity)
        {
            SetAuthorizationHeader();
            var idValue = entity.GetType().GetProperty("Id").GetValue(entity);
            var response = await _httpClient.PutAsJsonAsync($"{_endpoint}/{idValue}", entity);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Hubo un problema al actualizar");
            }
            else
            {
                return response.IsSuccessStatusCode;
            }
        }
    }
}
