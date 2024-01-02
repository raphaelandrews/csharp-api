using ControleFacil.Api.Contract;
using ControleFacil.Api.Contract.NaturezaDeLancamento;
using ControleFacil.Api.Damain.Services.Interfaces;
using ControleFacil.Api.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ControleFacil.Api.Controllers
{
    
    [ApiController]
    [Route("titulos-apagar")]
    public class ApagarController : BaseController
    {
        private readonly IService<ApagarRequestContract, ApagarResponseContract, long> _apagarService;

        public ApagarController(
            IService<ApagarRequestContract, ApagarResponseContract, long> apagarService)
        {
            _apagarService = apagarService;
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(ApagarRequestContract contract)
        {
            try
            {  
                _idUser = GetIdUserLogado();
                return Created("", await _apagarService.Post(contract, _idUser));
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                _idUser = GetIdUserLogado();
                return Ok(await _apagarService.Get(_idUser));
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
                return Ok(await _apagarService.Get(id, _idUser));
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
        public async Task<IActionResult> Put(long id, ApagarRequestContract contract)
        {
            try
            {
                _idUser = GetIdUserLogado();
                return Ok(await _apagarService.Put(id, contract, _idUser));
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
                await _apagarService.Inactivation(id, _idUser);
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