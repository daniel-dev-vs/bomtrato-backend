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
        public IEnumerable<Processo> Get()
        {
            return Service.GetAll();
        }

        // GET api/<ProcessoController>/5
        [HttpGet("{id}")]
        public Processo Get(int id)
        {
            return Service.GetId(id);
        }

        // POST api/<ProcessoController>
        [HttpPost]
        public void Post([FromBody] Processo value)
        {
            Service.Add(value);
        }

        // PUT api/<ProcessoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] int value)
        {
            Processo processo = Service.GetId(value);

        }

        // DELETE api/<ProcessoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
