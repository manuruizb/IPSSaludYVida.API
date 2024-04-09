using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Helpers;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace IPSSaludYVida.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicioSaludController : Controller
    {
        private readonly dbIPSSaludYVidaContext _context;
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IServicioSaludRepository _servicioSaludRepository;
        private readonly ITriageRepository _triageRepository;
        public ServicioSaludController(
            dbIPSSaludYVidaContext context,
            IUsuariosRepository usuariosRepository,
            IServicioSaludRepository servicioSaludRepository,
            ITriageRepository triageRepository
            )
        {
            _context = context;
            _usuariosRepository = usuariosRepository;
            _servicioSaludRepository = servicioSaludRepository;
            _triageRepository = triageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Save(FormularioServicioSalud formularioServicioSalud)
        {
            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    usuario? user = await _usuariosRepository.SearchByDocument(formularioServicioSalud.document);
                    if (user == null)
                    {
                        return NotFound(new Result<dynamic>() { Message = "No existe un usuario con ese número de documento.", });
                    }

                    int idTriage = await _triageRepository.Save(formularioServicioSalud.triag);

                    formularioServicioSalud.service.idTriage = idTriage;
                    formularioServicioSalud.service.idUsuario = user.idUsuario;
                    await _servicioSaludRepository.Save(formularioServicioSalud.service);

                    dbTransaction.Commit();

                    return Ok(new Result<string>()
                    {
                        Success = true,
                        Data = "Servicio de salud guardado con éxito."
                    });
                }
                catch (Exception e)
                {
                    dbTransaction.Rollback();
                    return StatusCode(500, new Result<dynamic>() { Message = "Ha ocurrido un error", Data = e.Message });
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServiceByDocument(string document)
        {
            try
            {
                usuario? user = await _usuariosRepository.SearchByDocument(document);

                if (user == null)
                {
                    return NotFound(new Result<dynamic>() { Message = "No existe un usuario con ese número de documento." });
                }

                List<servicioSalud> listService = await _servicioSaludRepository.SearchByIdUsuario(user.idUsuario);

                return Ok(new Result<List<servicioSalud>>()
                {
                    Success = true,
                    Data = listService
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<dynamic>() { Message = "Ha ocurrido un error", Data = e.Message });
            }
        }
    }
}
