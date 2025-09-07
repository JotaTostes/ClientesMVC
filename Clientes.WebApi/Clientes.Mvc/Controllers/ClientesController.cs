using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using Clientes.Mvc.Models;

namespace Clientes.Mvc.Controllers
{
    public class ClientesController : Controller
    {
        private readonly HttpClient _http;

        public ClientesController(IHttpClientFactory clientFactory)
        {
            _http = clientFactory.CreateClient("Api");
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _http.GetFromJsonAsync<List<ClienteViewModel>>("clientes");
            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var response = await _http.PostAsJsonAsync("clientes", model);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Erro ao criar cliente.");
            return View(model);
        }
    }
}
