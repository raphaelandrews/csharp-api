using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using ControleFacil.Api.Contract.NaturezaDeLancamento;
using ControleFacil.Api.Damain.Services.Interfaces;
using ControleFacil.Api.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ControleFacil.Api.Controllers
{
    
    [ApiController]
    [Route("naturezas-de-lancamento")]
    public class NaturezaDeLancamentoController : BaseController
    {
        private readonly IService<NaturezaDeLancamentoRequestContract, NaturezaDeLancamentoResponseContract, long> _naturezaDeLancamentoService;

        public NaturezaDeLancamentoController(
            IService<NaturezaDeLancamentoRequestContract, NaturezaDeLancamentoResponseContract, long> naturezaDeLancamentoService)
        {
            _naturezaDeLancamentoService = naturezaDeLancamentoService;
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(NaturezaDeLancamentoRequestContract contract)
        {
            try
            {  
                _idUser = GetIdUserLogado();
                return Created("", await _naturezaDeLancamentoService.Post(contract, _idUser));
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ReturnModelBadRequest(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                _idUser = GetIdUserLogado();
                return Ok(await _naturezaDeLancamentoService.Get(_idUser));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ReturnModelNotFound(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                _idUser = GetIdUserLogado();
                return Ok(await _naturezaDeLancamentoService.Get(id, _idUser));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ReturnModelNotFound(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(long id, NaturezaDeLancamentoRequestContract contract)
        {
            try
            {
                _idUser = GetIdUserLogado();
                return Ok(await _naturezaDeLancamentoService.Put(id, contract, _idUser));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ReturnModelNotFound(ex));
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ReturnModelBadRequest(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Deletar(long id)
        {
            try
            {
                _idUser = GetIdUserLogado();
                await _naturezaDeLancamentoService.Inactivation(id, _idUser);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ReturnModelNotFound(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}