using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertModel;
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
            GetReponse(async () => await _advertsService.Add(model));

        // PUT api/adverts/confirm
        [HttpPut]
        [Route("confirm")]
        public Task<ActionResult> Confirm(int id, [FromBody] ConfirmAdvertModel model) => 
            GetReponse(async () => _advertsService.Confirm(model, _configuration.GetValue<string>("TopicArn")));
    }
}