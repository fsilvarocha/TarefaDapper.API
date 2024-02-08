using TarefaDapper.API.Models;

namespace TarefaDapper.API.Interface;

public interface ICategoriaRepositorie
{
    Task<List<Categoria>> GetAllAsync();
    Task<Categoria> GetByIdAsync(int id);
    Task<CategoriaContainer> GetAllWithCountAsync();
    Task<int> SaveAsync(Categoria categoria);
    Task<int> UpdateAsync(Categoria categoria);
    Task<int> DeleteAsync(int id);
}
