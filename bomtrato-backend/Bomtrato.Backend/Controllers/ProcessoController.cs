using Bomtrato.Backend.Data.Entities;
using Bomtrato.Backend.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bomtrato.Backend.controllers
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
        //[Authorize("Aprovador")]       
        public ActionResult<IEnumerable<Processo>> Get()
        {
            return Ok(Service.GetAll());
        }

        // GET api/<ProcessoController>/5
        [HttpGet("{id}")]
        //[Authorize("Aprovador")]
        public ActionResult<Processo> Get(int id)
        {
            return Ok(Service.GetId(id));
        }

        [HttpGet("{id}/existe")]
        //[Authorize("Aprovador")]
        public ActionResult<Processo> VerificaSeExisteProcesso(long numeroProcesso)
        {
            int? retorno = Service.VerificaSeExisteProcessoPorNumero(numeroProcesso);

            if (retorno == null)
                return Ok("{existe:false}");

            return Ok("{existe:true}");
        }

        // POST api/<ProcessoController>
        [HttpPost]
        //[Authorize("Aprovador")]
        public IActionResult Post([FromBody] Processo processo)
        {

            if (!ModelState.IsValid)
                return StatusCode(422);
            
            int? existeRegistro = Service.VerificaSeExisteProcessoPorNumero(processo.NumeroProcesso);


            if (existeRegistro != null && existeRegistro > 1)
                return StatusCode(409);


            Service.Add(processo);
            int idProcesso = Service.Save();


            return Ok(idProcesso);
        }

        // PUT api/<ProcessoController>/5
        [HttpPut("{id}")]       
        //[Authorize("Aprovador")]
        public IActionResult Put(int id, [FromBody]Processo processoRecebido)
        {
            if (!ModelState.IsValid)
                return StatusCode(422);

            Processo processo = Service.GetId(id);

            if (processo == null)
                return NotFound();

            processoRecebido.Id = id;
           

            Service.Update(processoRecebido);
            Service.Save();

            return Ok(processoRecebido);
        }

        // DELETE api/<ProcessoController>/5
        [HttpDelete("{id}")]  
        //[Authorize("Aprovador")]
        public IActionResult Delete(int id)
        {
            Processo processo = Service.GetId(id);
            Service.Remove(processo);
            Service.Save();

            return Ok();
        }
    }
}
