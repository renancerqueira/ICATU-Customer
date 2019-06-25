using ICATU.Costumer.Domain.Models;
using ICATU.Costumer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ICATU.Costumer.Api.Controllers
{
    [Route("api/Clientes")]
    public class ClientesController : ApiController
    {
        private ClientesService service;

        public ClientesController()
        {
            service = new ClientesService();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<ClienteModel> Get()
        {
            return service.GetAll();
        }

        // GET: api/Clientes/5
        [HttpGet]
        [Route("api/Clientes/{id}")]
        public ClienteModel Get(int id)
        {
            return service.Get(id);
        }

        // POST: api/Clientes
        [HttpPost]
        public IHttpActionResult Post([FromBody]ClienteModel model)
        {
            if (ModelState.IsValid)
            {
                service.Insert(model);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        // PUT: api/Clientes/5
        [HttpPut]
        [Route("api/Clientes/{id}")]
        public IHttpActionResult Put(int id, [FromBody]ClienteModel model)
        {
            if (ModelState.IsValid)
            {
                service.Update(model);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        // DELETE: api/Clientes/5
        [HttpDelete]
        [Route("api/Clientes/{id}")]
        public IHttpActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok();
        }
    }
}
