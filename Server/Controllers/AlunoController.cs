using BlazorApp.Server.ServicesServerAlunos;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("v0/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IServiceServerAluno _serviceAluno;
        public AlunoController(IServiceServerAluno serviceServerAluno)
        {
            _serviceAluno= serviceServerAluno;
        }

        // Saber se a tabela contém alunos.
        [HttpGet("any")]
        public async Task<ActionResult<bool>> GetAny()
        {
            return await _serviceAluno.GetAny();
        }

        // Saber qual é o primeiro aluno da tabela.
        [HttpGet("first")]
        public async Task<ActionResult<Alunos>> GetFirst()
        {
            return await _serviceAluno.GetFirst();
        }

        // Saber qual é o aluno da tabela que atende uma condição específica.
        [HttpGet("first/{id1:int}")]
        public async Task<ActionResult<Alunos>> GetFirst([FromRoute] int id1)
        {
            return await _serviceAluno.GetFirst(id1);
        }

        // Listar todos os alunos da tabela.
        [HttpGet("todosalunos")]
        public async Task<IEnumerable<Alunos>> GetTodosAlunos()
        {
            return await _serviceAluno.GetTodosAlunos();
        }

        // Saber se existe um único aluno que atende a uma condição específica.
        [HttpGet("single/{id1:int}")]
        public async Task<ActionResult<Alunos>> GetSingle([FromRoute] int id1)
        {
            return await _serviceAluno.GetSingle(id1);
        }

        // Saber a média das idades dos alunos da tabela.
        [HttpGet("average")]
        public async Task<ActionResult<double>> GetMedia()
        {
            return await _serviceAluno.GetMedia();
;       }

        // Saber a soma das idades dos alunos da tabela.
        [HttpGet("soma")]
        public async Task<ActionResult<int>> GetSoma()
        {
            return await _serviceAluno.GetSoma();
         
        }

        // Saber quantos alunos tem na tabela.
        [HttpGet("contar")]
        public async Task<ActionResult<int>> GetContar()
        {
            return await _serviceAluno.GetContar();
        }

        // Descobre valores excluivos das idades dos alunos.
        [HttpGet("idadesdistint")]
        public async Task<IEnumerable<int>> GetIdadesDistinAsync()
        {
            return await _serviceAluno.GetIdadesDistintAsync();
        }       
    }
}