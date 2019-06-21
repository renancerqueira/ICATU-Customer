using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ICATUCostumer.Domain.Model;
using ICATUCostumer.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ICATUCostumer.Application.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService service;

        public ClientesController()
        {
            service = new ClientesService();
        }

        // GET api/clientes/renan+cerqueira
        /// <summary>
        /// Retorna os dados dos clientes
        /// </summary>
        /// <remarks>Retorna os dados dos clientes pelo Id ou pelo nome</remarks>
        /// <param name="search">Passeo Id do cliente desejado para retornar seus dados. Passe o nome completo, ou parte dele, para retornar todos os clientes que correspondem.</param>
        /// <param name="page">Paginação - Número da página desejada</param>
        /// <param name="length">Paginação - Número da quantidade de registros desejados na página</param>
        /// <response code="200">Clientes encontrados</response>
        /// <response code="404">Nenhum cliente encontrado</response>
        [HttpGet("{search}")]
        public ActionResult<List<ClienteModel>> Read([FromRoute][Required]string search, [FromQuery]int page, [FromQuery]int length)
        {
            Guid id;

            if (Guid.TryParse(search, out id))
            {
                return new List<ClienteModel> { service.Get(id) };
            }

            return service.Search(search, page, length);
        }

        /// <summary>
        /// Cadastrar clientes
        /// </summary>
        /// <remarks>Cadastra um novo cliente no banco de dados</remarks>
        /// <param name="cliente">Objeto do tipo &#39;Cliente&#39; a ser cadastrado</param>
        /// <response code="201">Cliente cadastrado com sucesso</response>
        /// <response code="404">Objeto inválido. Verifique os dados enviados.</response>
        /// <response code="409">Este cliente já se encontra cadastrado em nosso banco de dados</response>
        [HttpPost]
        public ActionResult Create([FromBody]ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.Id.HasValue && service.Any(cliente.Id.Value))
                {
                    return StatusCode(409);
                }

                Guid newId = service.Insert(cliente);

                return CreatedAtAction(nameof(Read), newId);
            }

            return StatusCode(404);
        }

        // PUT api/values/
        /// <summary>
        /// Atualizar clientes
        /// </summary>
        /// <remarks>Atualiza os dados desejados de um cliente</remarks>
        /// <param name="cliente">Objeto do tipo &#39;Cliente&#39; com os dados a serem atualizados</param>
        /// <response code="204">Cliente atualizado com sucesso</response>
        /// <response code="404">Nenhum cliente encontrado</response>
        [HttpPut]
        public ActionResult Put([FromBody]ClienteModel cliente)
        {
            if (!cliente.Id.HasValue || !service.Any(cliente.Id.Value))
            {
                return StatusCode(404);
            }

            service.Update(cliente);

            return StatusCode(204);
        }

        // DELETE api/values/b4ffb71a-f8e9-44a4-a56f-6b405d8dd8cb
        /// <summary>
        /// Deletar clientes
        /// </summary>
        /// <remarks>Deleta um cliente pelo seu Id</remarks>
        /// <param name="id">Id do cliente a ser deletado</param>
        /// <response code="200">Cliente deletado com sucesso</response>
        /// <response code="404">Nenhum cliente encontrado</response>
        [HttpDelete("{id}")]
        public ActionResult Delete([Required]Guid id)
        {
            if (!service.Any(id))
            {
                return StatusCode(404);
            }

            service.Delete(id);

            return StatusCode(200);
        }
    }
}
