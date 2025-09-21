using AuthApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository pUsuarioRepository)
        {
            usuarioRepository = pUsuarioRepository;
        }

        [HttpGet("usuarios")]
        [Authorize]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await usuarioRepository.GetAllUsuariosAsync();
            return Ok(usuarios);
        }
    }
}
