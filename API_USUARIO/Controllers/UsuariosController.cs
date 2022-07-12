using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_USUARIO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GETUsuarios()
        {
            var usuarios = Banco.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("GETCPF")]
        public IActionResult GetByCPF(string cpf)
        {
            var usuario = Banco.BuscaID(cpf); 
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult ADDUsuario(Usuario usuario)
        {
            Banco.Inserir(usuario);
            return Ok("Incluído com sucesso!");
        }

        [HttpDelete]
        public IActionResult Delete(string cpf)
        {
            Banco.Deletar(cpf);
            return Ok("Excluido com sucesso!");
        }

        [HttpPut]
        public IActionResult AttUsuario(Usuario usuario)
        {
            Banco.Update(usuario);
            return Ok("Atualizado com sucesso!");
        }
    }
}
