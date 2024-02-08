using Dapper;
using TarefaDapper.API.Data;
using TarefaDapper.API.Interface;
using TarefaDapper.API.Models;

namespace TarefaDapper.API.Repositories
{
    public class CategoriaRepositorie : ICategoriaRepositorie
    {
        private readonly DbSession _dbSession;
        private string Sql = string.Empty;

        public CategoriaRepositorie(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            using (var session = _dbSession.Connection)
            {
                Sql = "SELECT * FROM [CatalogoMinimalAPI].[dbo].[Categoria]";
                List<Categoria> categorias = (await session.QueryAsync<Categoria>(sql: Sql)).ToList();
                return categorias;
            }
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            using (var session = _dbSession.Connection)
            {
                Sql = "SELECT * FROM [CatalogoMinimalAPI].[dbo].[Categoria] WHERE Id = @id";
                Categoria categoria = await session.QueryFirstOrDefaultAsync<Categoria>(sql: Sql, param: new { id });

                return categoria;
            }
        }

        public async Task<CategoriaContainer> GetAllWithCountAsync()
        {
            using (var session = _dbSession.Connection)
            {
                Sql = @"SELECT count(*) FROM [CatalogoMinimalAPI].[dbo].[Categoria]
                        SELECT * FROM [CatalogoMinimalAPI].[dbo].[Categoria]";

                var reader = await session.QueryMultipleAsync(sql: Sql);

                return new CategoriaContainer
                {
                    Contador = (await reader.ReadAsync<int>()).FirstOrDefault(),
                    Categorias = (await reader.ReadAsync<Categoria>()).ToList()
                };
            }
        }

        public async Task<int> SaveAsync(Categoria categoria)
        {
            using (var session = _dbSession.Connection)
            {
                Sql = @"insert into categoria(Nome, Descricao) values (@Nome, @Descricao)";
                var result = await session.ExecuteAsync(sql: Sql, param: categoria);
                return result;
            }
        }

        public async Task<int> UpdateAsync(Categoria categoria)
        {
            using (var session = _dbSession.Connection)
            {
                Sql = @"Update categoria set Nome = @Nome, Descricao= @Descricao where id = @id";
                var result = await session.ExecuteAsync(sql: Sql, param: categoria);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var session = _dbSession.Connection)
            {
                Sql = @"delete from categoria where id = @id";
                var result = await session.ExecuteAsync(sql: Sql, param: new { id });
                return result;
            }
        }
    }
}
