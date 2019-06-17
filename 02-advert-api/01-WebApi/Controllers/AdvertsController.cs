using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertModel;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
       protected readonly IAdvertsService _advertsService;

        public AdvertsController(IAdvertsService advertsService)
        {
            _advertsService = advertsService;
        }

        // POST api/adverts/create
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(404), ProducesResponseType(201, Type = typeof(Advert))]
        public void Create([FromBody] Advert model) => 
            _advertsService.Add(model);

        // PUT api/adverts/confirm
        [HttpPut]
        [Route("Confirm")]
        public void Confirm(int id, [FromBody] ConfirmAdvertModel model) => 
            _advertsService.Confirm(model);
    }
}