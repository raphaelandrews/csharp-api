using ControleFacil.Api.Contract.PlayerNorms;
using ControleFacil.Api.Domain.Services.Interfaces;
using ControleFacil.Api.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFacil.Api.Controllers
{

    [ApiController]
    [Route("player-norms")]
    public class PlayerNormsController : BaseController
    {
        private readonly IService<PlayerNormsRequestContract, PlayerNormsResponseContract, long> _playerNormsService;

        public PlayerNormsController(
            IService<PlayerNormsRequestContract, PlayerNormsResponseContract, long> playerNormsService)
        {
            _playerNormsService = playerNormsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(PlayerNormsRequestContract contrato)
        {
            try
            {
                _idUser = GetIdUserLogged();
                return Created("", await _playerNormsService.Post(contrato, _idUser));
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
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                _idUser = GetIdUserLogged();
                return Ok(await _playerNormsService.Get(0));
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
                _idUser = GetIdUserLogged();
                return Ok(await _playerNormsService.Get(id, _idUser));
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
        public async Task<IActionResult> Put(long id, PlayerNormsRequestContract contrato)
        {
            try
            {
                _idUser = GetIdUserLogged();
                return Ok(await _playerNormsService.Put(id, contrato, _idUser));
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
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                _idUser = GetIdUserLogged();
                await _playerNormsService.Inactivation(id, _idUser);
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