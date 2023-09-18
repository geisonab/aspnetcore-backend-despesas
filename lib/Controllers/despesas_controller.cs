using despesas_pessoais.Interfaces;
using despesas_pessoais.Models;
using Microsoft.AspNetCore.Mvc;

namespace despesas_pessoais.Controllers
{
    [ApiController]
    [Route("v1/[Controller]")]
    public class DespesasController : ControllerBase
    {
        private readonly IDespesasRepository _repository;
        public DespesasController(IDespesasRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("BuscarTodos",Name = "BuscarDespesas")]
        public async Task<ActionResult<IEnumerable<DespesasModel>>> Get()
        {
            try
            {
                var ret = await _repository.BuscarDespesas();
                return Ok(ret);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Cadastrar",Name = "CriarDespesa")]
        public async Task<ActionResult> CadastrarDespesa(DespesasModel despesa)
        {
            try
            {
                _repository.CriarDespesa(despesa);
                if(await _repository.SaveAllAsync())
                {return Ok(despesa);}
                else{return BadRequest("Erro ao gravar");}
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Excluir",Name = "ExcluirDespesa")]
        public async Task<ActionResult> ExcluirDespesa(DespesasModel despesa)
        {
            try
            {
                _repository.ExcluirDespesa(despesa);
                if(await _repository.SaveAllAsync())
                {return Ok();}
                else{return BadRequest("Erro ao excluir");}
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao excluir");
            }
        }
    }
}