using Microsoft.AspNetCore.Mvc;

namespace IPSSaludYVida.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MasterController : ControllerBase
    {
        private readonly IMasterRepository _masterRepository;
        public MasterController(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int table, string? param)
        {
            try
            {
                var data = await _masterRepository.GetAll((TablesEnum)table, param);

                if (data is null || (data is IEnumerable<dynamic> && data.Count == 0))
                    return NotFound(new Result<dynamic>() { Message = "No se encontró información.", });

                return Ok(new Result<dynamic>()
                {
                    Success = true,
                    Data = data
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<dynamic>() { Message = "Ha ocurrido un error", Data = e.Message });
            }

        }
    }
}
