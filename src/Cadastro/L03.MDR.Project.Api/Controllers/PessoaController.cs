using MDR.Cadastro.Application.DTO;
using MDR.Cadastro.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace L03.MDR.Project.Api.Controllers
{
    [ApiController]
    [Route("{tenant}/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService) => _pessoaService = pessoaService;

        [HttpGet("GetPessoas")]
        public async Task<IEnumerable<PessoaDTO>> GetAll()
        {
            return await _pessoaService.RecuperarPessoas();
        }
    }
}
