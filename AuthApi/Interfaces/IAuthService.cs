using AuthApi.DTOs.UsuariosDTOs;

namespace AuthApi.Interfaces
{
    public interface IAuthService
    {
        Task<UsuarioRespuestaDTO> RegistrarAsync(UsuarioRegistroDTO dto);
        Task<UsuarioRespuestaDTO> LoginAsync(UsuarioLoginDTO dto);
    }
}
