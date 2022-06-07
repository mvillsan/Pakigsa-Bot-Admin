using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Server.DataAccess;
using Admin.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Admin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstablishmentController : ControllerBase
    {
        EstablishmentDataAccessLayer objEstablishment = new EstablishmentDataAccessLayer();

        [HttpGet]
        public Task<List<Establishment>> Get()
        {
            return objEstablishment.GetAllEstablishments();
        }

        [HttpGet("{id}")]
        public Task<Establishment> Get(string id)
        {
            return objEstablishment.GetEstablishmentData(id);
        }

        [HttpPost]
        public void Post([FromBody] Establishment establishment)
        {
            objEstablishment.AddEstablishment(establishment);
        }

        [HttpPut]
        public void Put([FromBody] Establishment establishment)
        {
            objEstablishment.UpdateEstablishment(establishment);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            objEstablishment.DeleteEstablishment(id);
        }
    }
}
