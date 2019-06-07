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

        // POST api/values
        [HttpPost]
        public void Add([FromBody] Advert model) => 
            _advertsService.Add(model);

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ConfirmAdvertModel model) => 
            _advertsService.Confirm(model);
    }
}
