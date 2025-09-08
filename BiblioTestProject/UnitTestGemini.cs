using Microsoft.Extensions.Configuration;
using Service.Models;
using Service.Services;
using System.Text;
using System.Text.Json;

namespace BiblioTestProject
{
    public class UnitTestGemini
    {
        [Fact]
        public async Task TestObtenerResumenLibroIA()
        {
            await LoginTest();
            //leemos la api key desde appsettings.json
            var configuration = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                  .AddEnvironmentVariables()
                  .Build();

            var apiKey = configuration["ApiKeyGemini"];
            var url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key= " + apiKey;

            var prompt = $"2 chistes";

            var payload = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            var json = JsonSerializer.Serialize(payload);
            using var client = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(result);
            var texto = doc.RootElement
               .GetProperty("candidates")[0]
               .GetProperty("content")
               .GetProperty("parts")[0]
               .GetProperty("text")
               .GetString();

            Console.WriteLine($"Respuesta de IA: {texto}");
            Assert.True(response.IsSuccessStatusCode);
        }

        private async Task LoginTest()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            Console.WriteLine($"Leyendo configuración...: {config}");
            var serviceAuth = new AuthService(config);
            Console.WriteLine($"Iniciando login...: {serviceAuth}");
            var token = await serviceAuth.Login(new Login
            {
                Username = "pianettilucio@gmail.com",
                Password = "12345678"
            });
            Console.WriteLine($"Token obtenido: {token}");
            GeminiService.jwtToken = token;
        }

        [Fact]
        public async Task TestServicioGemini()
        {
            await LoginTest();
            //leemos la api key desde appsettings.json
            var configuration = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                  .AddEnvironmentVariables()
                  .Build();
            var prompt = $"cuentame un chiste";
            var servicio = new GeminiService(configuration);
            var resultado = await servicio.GetPrompt(prompt);
            Console.WriteLine($"Respuesta de IA desde servicio: {resultado}");
            Assert.NotNull(resultado);
        }

    }
}