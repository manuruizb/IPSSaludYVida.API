using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Helpers;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace IPSSaludYVida.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly dbIPSSaludYVidaContext _context;
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IOposicionDonacionRepository _oposicionDonacionRepository;
        private readonly IVoluntadAnticipadaRepository _voluntadAnticipadaRepository;
        private readonly IUsuarioPaisesRepository _usuariosPaisesRepository;
        private readonly IUsuarioDiscapacidadRepository _usuarioDiscapacidadRepository;
        public UsuariosController(
            dbIPSSaludYVidaContext context,
            IUsuariosRepository usuariosRepository,
            IOposicionDonacionRepository oposicionDonacionRepository,
            IVoluntadAnticipadaRepository voluntadAnticipadaRepository,
            IUsuarioPaisesRepository usuarioPaisesRepository,
            IUsuarioDiscapacidadRepository usuarioDiscapacidadRepository
            )
        {
            _context = context;
            _usuariosRepository = usuariosRepository;
            _oposicionDonacionRepository = oposicionDonacionRepository;
            _voluntadAnticipadaRepository = voluntadAnticipadaRepository;
            _usuariosPaisesRepository = usuarioPaisesRepository;
            _usuarioDiscapacidadRepository = usuarioDiscapacidadRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Save(FormularioUsuario formularioUsuario)
        {

            //Este método permite hacer rollback, un método transaction, si no se cumple lo del commit, él hace rollback y deja todo igual.
            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    int idOposicion = await _oposicionDonacionRepository.Save(formularioUsuario.opoDonacion);
                    int idVoluntad = await _voluntadAnticipadaRepository.Save(formularioUsuario.voluntad);

                    formularioUsuario.user.idDonacion = idOposicion;
                    formularioUsuario.user.idVoluntad = idVoluntad;
                    Guid idUsuario = await _usuariosRepository.Save(formularioUsuario.user);

                    foreach(var item in formularioUsuario.paises)
                    {
                        item.idUsuario = idUsuario;
                        await _usuariosPaisesRepository.Save(item);
                    }
                    foreach (var item in formularioUsuario.discapacidades)
                    {
                        item.idUsuario = idUsuario;
                        await _usuarioDiscapacidadRepository.Save(item);
                    }

                    dbTransaction.Commit();

                    return Ok(new Result<string>()
                    {
                        Success = true,
                        Data = "Usuario guardado con éxito."
                    });
                }
                catch (Exception e)
                {
                    dbTransaction.Rollback();
                    return StatusCode(500, new Result<dynamic>() { Message = "Ha ocurrido un error", Data = e.Message });
                }
            }


        }

        [HttpPut]
        public async Task<IActionResult> Update(FormularioUsuario formularioUsuario)
        {
            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _oposicionDonacionRepository.Update(formularioUsuario.opoDonacion);
                    await _voluntadAnticipadaRepository.Update(formularioUsuario.voluntad);

                    await _usuariosRepository.UpdateUser(formularioUsuario.user);

                    await _usuariosPaisesRepository.Delete(formularioUsuario.user.idUsuario);
                    foreach (var item in formularioUsuario.paises)
                    {
                        item.idUsuario = formularioUsuario.user.idUsuario;
                        await _usuariosPaisesRepository.Save(item);
                    }

                    await _usuarioDiscapacidadRepository.Delete(formularioUsuario.user.idUsuario);
                    foreach (var item in formularioUsuario.discapacidades)
                    {
                        item.idUsuario = formularioUsuario.user.idUsuario;
                        await _usuarioDiscapacidadRepository.Save(item);
                    }

                    dbTransaction.Commit();

                    return Ok(new Result<string>()
                    {
                        Success = true,
                        Data = "Usuario actualizado con éxito."
                    });
                }
                catch (Exception e)
                {
                    dbTransaction.Rollback();
                    return StatusCode(500, new Result<dynamic>() { Message = "Ha ocurrido un error.", Data = e.Message });
                }
            }
        }
    }
}
