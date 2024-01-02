using ControleFacil.Api.Contract.NaturezaDeLancamento;
using ControleFacil.Api.Damain.Services.Interfaces;
using ControleFacil.Api.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFacil.Api.Controllers
{
    
    [ApiController]
    [Route("titulos-areceber")]
    public class AreceberController : BaseController
    {
        private readonly IService<AreceberRequestContract, AreceberResponseContract, long> _areceberService;

        public AreceberController(
            IService<AreceberRequestContract, AreceberResponseContract, long> areceberService)
        {
            _areceberService = areceberService;
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(AreceberRequestContract contract)
        {
            try
            {  
                _idUser = GetIdUserLogado();
                return Created("", await _areceberService.Post(contract, _idUser));
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
                return Ok(await _areceberService.Get(_idUser));
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
                return Ok(await _areceberService.Get(id, _idUser));
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
        public async Task<IActionResult> Put(long id, AreceberRequestContract contract)
        {
            try
            {
                _idUser = GetIdUserLogado();
                return Ok(await _areceberService.Put(id, contract, _idUser));
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
                await _areceberService.Inactivation(id, _idUser);
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