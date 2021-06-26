using Backend.Me.Appservice.Interface;
using Backend.Me.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplicationME.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : Controller
    {
        private readonly IStatusAppservice _service;

        public StatusController(IStatusAppservice service)
        {
            _service = service;
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] StatusRequestVM statusRequestVM)
        {
            try
            {
                var retorno = _service.Validar(statusRequestVM);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir.");
            }
        }

        
    }
}
