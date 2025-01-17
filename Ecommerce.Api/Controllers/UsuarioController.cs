﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Servicio.Contrato;
using Ecommerce.DTO;
namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("Lista/{rol:alpha}/{buscar:alpha?}")]

        public async Task<IActionResult> Lista(string rol, string buscar = "NA")
        {
            var response = new ResponseDTO<List<UsuarioDTO>>();

            try
            {

                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _usuarioService.Lista(rol, buscar);

            }catch (Exception ex)
            {
                response.EsCorrecto=false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }

        [HttpGet("Obtener/{id:int}")]

        public async Task<IActionResult>Obtener(int id)
        {
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _usuarioService.Obtener(id);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }

          [HttpPost("Crear")]
        public async Task<IActionResult>Crear([FromBody] UsuarioDTO modelo) 
        {
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _usuarioService.Crear(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }

        [HttpPost("Autorizacion")]
        public async Task<IActionResult> Autorizacion([FromBody] LoginDTO modelo)
        {
            var response = new ResponseDTO<SessionDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _usuarioService.Autorizacion(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] UsuarioDTO modelo)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _usuarioService.Editar(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }

        [HttpDelete("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _usuarioService.Eliminar(id);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }
    }
}
