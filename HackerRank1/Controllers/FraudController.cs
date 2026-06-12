using System.Threading.Tasks;
using HackerRank1.Entities;
using HackerRank1.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackerRank1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FraudController : ControllerBase
    {
        private readonly IFraudService _fraudService;

        public FraudController(IFraudService fraudService)
        {
            _fraudService = fraudService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFraud([FromBody] Fraud fraud)
        {
            if (fraud == null)
                return BadRequest(new { message = "Datos inválidos" });

            if (string.IsNullOrWhiteSpace(fraud.ImpostorDetails))
                return BadRequest(new { message = "Los detalles del impostor son obligatorios" });

            var created = await _fraudService.CreateFraudAsync(fraud);
            return Ok(created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFrauds()
        {
            var frauds = await _fraudService.GetAllFraudsAsync();
            return Ok(frauds);
        }
    }
}