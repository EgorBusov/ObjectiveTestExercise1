using Microsoft.AspNetCore.Mvc;
using ObjectiveTestExercise.Models;
using ObjectiveTestExercise.Services.Interfaces;

namespace ObjectiveTestExercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;
        public SubscribeController(ISubscribeService subscribeService) 
        {
            _subscribeService = subscribeService;
        }

        /// <summary>
        /// Добавление подписки
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Subscribe")]
        public IActionResult Subscribe([FromBody] AddSubscribeModel model)
        {
            bool check = _subscribeService.AddSubscribe(model);

            if (check)
            {
                return Ok("Success");
            }

            return BadRequest("Unsuccessfully");
        }

        /// <summary>
        /// Получение актуальных цен
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetActualPrices")]
        public async Task<IEnumerable<ActualPriceModel>> GetActualPrices()
        {
            var prices = await _subscribeService.GetPricesAndUrls();
            return prices;
        }
    }
}
