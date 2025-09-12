using Service.Interfaces;
using Service.Models;
using Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UsuarioService : GenericService<Usuario>, IUsuarioService
    {
        public UsuarioService(HttpClient? httpClient = null) : base(httpClient)
        {
            // Nada extra: el constructor base ya configura _endpoint, _options y Authorization
        }

        //private void SetAuthorizationHeader()
        //{
        //    if (!string.IsNullOrEmpty(GenericService<object>.jwtToken))
        //    {
        //        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GenericService<object>.jwtToken);
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Token no definido.", nameof(GenericService<object>.jwtToken));
        //    }
        //}

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            SetAuthorizationHeader();
            var response = await _httpClient.GetAsync($"{_endpoint}/byemail?email={email}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<Usuario>(content, _options);
        }
    }
}