using ControleFacil.Api.Contract.PlayerPodiums;
using ControleFacil.Api.Domain.Services.Interfaces;
using ControleFacil.Api.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFacil.Api.Controllers
{

    [ApiController]
    [Route("player-podiums")]
    public class PlayerPodiumsController : BaseController
    {
        private readonly IService<PlayerPodiumsRequestContract, PlayerPodiumsResponseContract, long> _playerPodiumsService;

        public PlayerPodiumsController(
            IService<PlayerPodiumsRequestContract, PlayerPodiumsResponseContract, long> playerPodiumsService)
        {
            _playerPodiumsService = playerPodiumsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(PlayerPodiumsRequestContract contrato)
        {
            try
            {
                _idUser = GetIdUserLogged();
                return Created("", await _playerPodiumsService.Post(contrato, _idUser));
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
                return Ok(await _playerPodiumsService.Get(0));
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
                return Ok(await _playerPodiumsService.Get(id, _idUser));
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
        public async Task<IActionResult> Put(long id, PlayerPodiumsRequestContract contrato)
        {
            try
            {
                _idUser = GetIdUserLogged();
                return Ok(await _playerPodiumsService.Put(id, contrato, _idUser));
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
                await _playerPodiumsService.Inactivation(id, _idUser);
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