using System.Threading.Tasks;
using AdvertModel;
using AdvertModel.Confirm;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApi.Controllers
{
    [Route("api/adverts")]
    [ApiController]
    public class AdvertsController : CustomController
    {
        private readonly IAdvertsService _advertsService;
        private readonly IConfiguration _configuration;
        public AdvertsController(IAdvertsService advertsService, IConfiguration configuration)
        {
            _advertsService = advertsService;
            _configuration = configuration;
        }

        // POST api/adverts/create
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(404), ProducesResponseType(201, Type = typeof(Advert))]
        public Task<ActionResult> Create([FromBody] Advert model) => 
            GetReponse(
                async () => 
                    await _advertsService.Add(model));

        // PUT api/adverts/confirm
        [HttpPut]
        [Route("confirm")]
        [ProducesResponseType(404), ProducesResponseType(201, Type = typeof(ConfirmAdvertModel))]
        public Task<ActionResult> Confirm([FromBody] ConfirmAdvertModel model) => 
            GetReponse(
                async () => 
                    await _advertsService.Confirm(model, _configuration.GetValue<string>("TopicArn")));
    }
}