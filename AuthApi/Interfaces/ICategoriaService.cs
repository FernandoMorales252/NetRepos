using AuthApi.DTOs.CategoriaDTOs;
using System.Threading.Tasks;

namespace AuthApi.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<CategoriaResponseDTO>> GetAllAsync();
        Task<CategoriaResponseDTO?> GetByIdAsync(int id);
        Task<CategoriaResponseDTO> CreateAsync(CategoriaCreateDTO dto);
        Task<bool> UpdateAsync(int id, CategoriaUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
