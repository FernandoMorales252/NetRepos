using AuthApi.DTOs.UsuariosDTOs;
using AuthApi.Entidades;

namespace AuthApi.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuarios?> GetByEmailAsync(string email);

        Task<Usuarios> AddAsync(Usuarios usuario);

        Task<List<UsuarioListadoDTO>> GetAllUsuariosAsync();
    }
}
