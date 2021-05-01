using bomtrato.backend.models.entities;
using bomtrato.backend.service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bomtrato.backend.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {
        private IProcessoService Service;
        public ProcessoController(IProcessoService service) 
        {
            this.Service = service;
        }

        // GET: api/<ProcessoController>
        [HttpGet]
        public ActionResult<IEnumerable<Processo>> Get()
        {
            return Ok(Service.GetAll());
        }

        // GET api/<ProcessoController>/5
        [HttpGet("{id}")]
        public ActionResult<Processo> Get(int id)
        {
            return Ok(Service.GetId(id));
        }

        // POST api/<ProcessoController>
        [HttpPost]
        public IActionResult Post([FromBody] Processo processo)
        {
            Service.Add(processo);
            Service.Save();

            return Ok();
        }

        // PUT api/<ProcessoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Processo processoRecebido)
        {
            Processo processo = Service.GetId(id);

            if (processo == null)
                return NotFound();

            processoRecebido.Id = id;
           

            Service.Update(processoRecebido);
            Service.Save();

            return Ok();
        }

        // DELETE api/<ProcessoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Processo processo = Service.GetId(id);
            Service.Remove(processo);
            Service.Save();

            return Ok();
        }
    }
}
