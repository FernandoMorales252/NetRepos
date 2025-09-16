using AuthApi.Entidades;

namespace AuthApi.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<CategoriaFM>> GetAllAsync();
        Task<CategoriaFM?> GetByIdAsync(int id);
        Task<CategoriaFM> AddAsync(CategoriaFM entity);
        Task<bool> UpdateAsync(CategoriaFM entity);
        Task<bool> DeleteAsync(int id);
    }
}
