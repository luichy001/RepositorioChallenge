using Backend.Me.Appservice.Interface;
using Backend.Me.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplicationME.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoAppservice _service;
        private const int LimiteCarateresCodigoPedido = 6;
        public PedidoController(IPedidoAppservice service)
        {
            _service = service;
        }

        [HttpGet("Get")]
        public IActionResult Get(string pedido)
        {
            try
            {
                if (pedido.Length > LimiteCarateresCodigoPedido)
                {
                    return BadRequest("Formato de Código Inválido");
                }

                var retorno = _service.Obter(pedido);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao obter.");
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] PedidoRequestVM pedidoRequestVM)
        {
            try
            {
                if(pedidoRequestVM.pedido.Length > LimiteCarateresCodigoPedido)
                {
                    return BadRequest("Formato de Código Inválido");
                }

                var retorno = _service.Inserir(pedidoRequestVM);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir.");
            }
        }
        [HttpPut("Put")]
        public IActionResult Put([FromBody] PedidoRequestVM pedidoRequestVM)
        {
            try
            {
                var retorno = _service.Atualizar(pedidoRequestVM);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir.");
            }
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(string pedido)
        {
            try
            {
                var retorno = _service.Deletar(pedido);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir.");
            }
        }
        
    }
}
