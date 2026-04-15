using api_dotnet_um.Models;
using api_dotnet_um.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_dotnet_um.Controllers
{
    [RoutePrefix("api/contatos")]
    public class ContatosController : ApiController
    {

        // injecao de dependencia
        private readonly ContatoRepository _repository = new ContatoRepository();


        // GET ALL
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var contatos = _repository.ListarTodos();
            return Ok(contatos);
        }

        // GET BY ID
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            var contato = _repository.ListarTodos().FirstOrDefault(x => x.Id == id);

            if(contato == null)
            {
                return NotFound();
            }

            return Ok(contato);

        }

        // POST
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody] Contato contato)
        {
            if (contato == null)
                return BadRequest("Dados inválidos");

            _repository.Salvar(contato);

            return Created("", contato);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody] Contato contato)
        {
            if (contato == null)
                return BadRequest("Dados inválidos");

            var existente = _repository.ListarTodos().FirstOrDefault(c => c.Id == id);

            if (existente == null)
                return NotFound();

            existente.Nome = contato.Nome;
            existente.Email = contato.Email;

            _repository.Salvar(existente);

            return Ok(existente);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var existente = _repository.ListarTodos().FirstOrDefault(c => c.Id == id);

            if (existente == null)
            { 
            return NotFound();
        }
            _repository.Remover(id);

            return Ok();
        }
    }
}