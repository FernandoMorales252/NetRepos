using AuthApi.DTOs.CategoriaDTOs;
using AuthApi.Entidades;
using AuthApi.Interfaces;

namespace AuthApi.Servicios
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repo;

        public CategoriaService(ICategoriaRepository repo) => _repo = repo;

        public async Task<List<CategoriaResponseDTO>> GetAllAsync() =>
            (await _repo.GetAllAsync()).Select(x => new CategoriaResponseDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion
            }).ToList();

        public async Task<CategoriaResponseDTO?> GetByIdAsync(int id)
        {
            var x = await _repo.GetByIdAsync(id);
            return x == null ? null : new CategoriaResponseDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion
            };
        }

        public async Task<CategoriaResponseDTO> CreateAsync(CategoriaCreateDTO dto)
        {
            var entity = new CategoriaFM { Nombre = dto.Nombre.Trim(), Descripcion = dto.Descripcion.Trim() };
            var saved = await _repo.AddAsync(entity);
            return new CategoriaResponseDTO { Id = saved.Id, Nombre = saved.Nombre, Descripcion = saved.Descripcion };
        }

        public async Task<bool> UpdateAsync(int id, CategoriaUpdateDTO dto)
        {
            var current = await _repo.GetByIdAsync(id);
            if (current == null) return false;
            current.Nombre = dto.Nombre.Trim();
            current.Descripcion = dto.Descripcion.Trim();
            return await _repo.UpdateAsync(current);
        }

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}

