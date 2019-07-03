using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertModel;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/adverts")]
    [ApiController]
    public class AdvertsController : CustomController
    {
       protected readonly IAdvertsService _advertsService;

        public AdvertsController(IAdvertsService advertsService)
        {
            _advertsService = advertsService;
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
            GetReponse(async () => _advertsService.Confirm(model));
    }
}