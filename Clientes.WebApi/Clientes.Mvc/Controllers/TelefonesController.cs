using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using Clientes.Mvc.Models;

namespace Clientes.Mvc.Controllers
{
    public class TelefonesController : Controller
    {
        private readonly HttpClient _http;

        public TelefonesController(IHttpClientFactory clientFactory)
        {
            _http = clientFactory.CreateClient("Api");
        }

        public async Task<IActionResult> Index(Guid clienteId)
        {
            var telefones = await _http.GetFromJsonAsync<List<TelefoneViewModel>>($"clientes/{clienteId}/telefones");
            ViewBag.ClienteId = clienteId;
            return View(telefones);
        }

        public async Task<IActionResult> Create(Guid clienteId)
        {
            var tipos = await _http.GetFromJsonAsync<List<TipoTelefoneViewModel>>("tipostelefone");
            ViewBag.TiposTelefone = tipos;
            return View(new TelefoneViewModel { CodigoCliente = clienteId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(TelefoneViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var response = await _http.PostAsJsonAsync($"clientes/{model.CodigoCliente}/telefones", model);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index", new { clienteId = model.CodigoCliente });

            ModelState.AddModelError("", "Erro ao adicionar telefone.");
            return View(model);
        }
    }
}
