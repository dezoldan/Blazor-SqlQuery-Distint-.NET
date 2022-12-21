using BlazorApp.Shared;

namespace BlazorApp.Server.ServicesServerAlunos
{
    public interface IServiceServerAluno
    {
        Task<bool> GetAny();
        Task<int> GetContar();
        Task<Alunos> GetFirst();
        Task<Alunos> GetFirst(int id1);
        Task<IEnumerable<int>> GetIdadesDistintAsync();
        Task<double> GetMedia();
        Task<Alunos> GetSingle(int id1);
        Task<int> GetSoma();
        Task<IEnumerable<Alunos>> GetTodosAlunos();
    }
}
