using BlazorApp.Server.Data;
using BlazorApp.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.Design;

namespace BlazorApp.Server.ServicesServerAlunos
{
    public class ServiceServerAluno : IServiceServerAluno
    {
        private readonly DataContext _dataContext;
        public ServiceServerAluno(DataContext dataContext)
        {
            _dataContext= dataContext;  
        }

        // Saber se a tabela contém alunos.
        public async Task<bool> GetAny()
        {
            return await _dataContext.TblTeste3.AnyAsync();
        }      
        
        // Retorna o primeiro aluno da tabela.
        public async Task<Alunos> GetFirst()
        {
            // Verifica se a tabela contém alunos.
            if (await _dataContext.TblTeste3.AnyAsync())
            {
                return await _dataContext.TblTeste3.FirstAsync();
            }
            else
            {
                return null!;
            }
        }

        // Retorna o aluno da tabela que atende uma condição específica.
        public async Task<Alunos> GetFirst(int id1)
        {
            // Verifica se a tabela contém alunos.
            if (await _dataContext.TblTeste3.AnyAsync())
            {
                return await _dataContext.TblTeste3.FirstAsync(x => x.Id == id1);
            }
            else
            {
                return null!;
            }
        }

        // Retorna todos os elementos da tabela.
        // Desabilitando o controle de alterações a consulta é mais rápida.
        public async Task<IEnumerable<Alunos>> GetTodosAlunos()
        {
            return await _dataContext.TblTeste3.AsNoTracking().ToArrayAsync();
        }

        // Retorna o aluno da tabela, desde que único, que atende a uma condição específica.
        // Gera uma exceção.
        public async Task<Alunos> GetSingle(int id1)
        {
            try
            {
                // Verifica se a tabela contém alunos.
                if (await _dataContext.TblTeste3.AnyAsync())
                {
                    return await _dataContext.TblTeste3.SingleAsync(a => a.Id == id1);
                }
                else
                {
                    return null!;
                }
            }
            catch (Exception)
            {
                throw new Exception("Não há um aluno único na tabela que atende a essa condição");
            }
        }

        // Saber a média das idades dos alunos da tabela.
        public async Task<double> GetMedia()
        {
            return await _dataContext.TblTeste3.AverageAsync(x => x.Idade);
        }

        // Saber a soma das idades dos alunos da tabela.
        public async Task<int> GetSoma()
        {
            return await _dataContext.TblTeste3.SumAsync(x => x.Idade);
        }

        // Saber quantos alunos tem na tabela.
        public async Task<int> GetContar()
        {
            return await _dataContext.TblTeste3.CountAsync();
        }

        // Vídeo #45.
        // Descobre as idades e exclui as idades repetidas. Valores exclusivos.
        public async Task<IEnumerable<int>> GetIdadesDistintAsync()
        {
           IEnumerable<int> idadesdistint = await _dataContext
                .Database.SqlQuery<int>($"SELECT [Idade] FROM TblTeste").ToArrayAsync();
            return idadesdistint.Distinct();
        }       
    }
}