using Clientes.Domain.Entities;
using Clientes.Mvc.Configuration;
using Clientes.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Clientes.Mvc.Controllers
{
    public class ClientesController : Controller
    {
        private readonly HttpClient _http;
        private readonly ApiSettings _apiSettings;

        public ClientesController(IHttpClientFactory clientFactory, IOptions<ApiSettings> apiSettings)
        {
            _http = clientFactory.CreateClient("Api");
            _apiSettings = apiSettings.Value;
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
        public async Task<IActionResult> Edit(Guid id)
        {
            Cliente clienteEntity = null;
            var response = await _http.GetAsync(_apiSettings.BaseUrl + "/clientes/" + id);

            if (response.IsSuccessStatusCode)
                clienteEntity = await response.Content.ReadFromJsonAsync<Cliente>();

            if (clienteEntity == null)
            {
                return NotFound();
            }

            var clienteViewModel = new ClienteViewModel
            {
                CodigoCliente = clienteEntity.CodigoCliente,
                RazaoSocial = clienteEntity.RazaoSocial,
                NomeFantasia = clienteEntity.NomeFantasia,
                TipoPessoa = clienteEntity.TipoPessoa,
                Documento = clienteEntity.Documento,
                Endereco = clienteEntity.Endereco,
                Complemento = clienteEntity.Complemento,
                Bairro = clienteEntity.Bairro,
                Cidade = clienteEntity.Cidade,
                UF = clienteEntity.UF,
                CEP = clienteEntity.CEP,
                Telefones = clienteEntity.Telefones.Select(t => new TelefoneViewModel
                {
                    CodigoTelefone = t.CodigoTelefone,
                    CodigoTipoTelefone = t.CodigoTipoTelefone,
                    NumeroTelefone = t.NumeroTelefone,
                    Operadora = t.Operadora
                }).ToList()

            };
            return View(clienteViewModel);
        }
    }
}
