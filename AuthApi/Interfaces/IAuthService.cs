using AuthApi.DTOs.UsuariosDTOs;

namespace AuthApi.Interfaces
{
    public interface IAuthService
    {
        Task<UsuarioRespuestaDTO> RegistrarAsync(UsuarioRegistroDTO usuarioRegistroDTO);
        Task<UsuarioRespuestaDTO> LoginAsync(UsuarioLoginDTO usuarioLoginto);
    }
}
