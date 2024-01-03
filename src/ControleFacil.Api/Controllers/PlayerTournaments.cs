using ControleFacil.Api.Contract.PlayerTournaments;
using ControleFacil.Api.Domain.Services.Interfaces;
using ControleFacil.Api.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFacil.Api.Controllers
{
    
    [ApiController]
    [Route("player-tournaments")]
    public class PlayerTournamentsController : BaseController
    {
        private readonly IService<PlayerTournamentsRequestContract, PlayerTournamentsResponseContract, long> _playerTournamentsService;

        public PlayerTournamentsController(
            IService<PlayerTournamentsRequestContract, PlayerTournamentsResponseContract, long> playerTournamentsService)
        {
            _playerTournamentsService = playerTournamentsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Adicionar(PlayerTournamentsRequestContract contrato)
        {
            try
            {  
                _idUser = GetIdUserLogged();
                return Created("", await _playerTournamentsService.Post(contrato, _idUser));
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
        public async Task<IActionResult> Obter()
        {
            try
            {
                _idUser = GetIdUserLogged();
                return Ok(await _playerTournamentsService.Get(_idUser));
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
        public async Task<IActionResult> Obter(long id)
        {
            try
            {
                _idUser = GetIdUserLogged();
                return Ok(await _playerTournamentsService.Get(id, _idUser));
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
        public async Task<IActionResult> Atualizar(long id, PlayerTournamentsRequestContract contrato)
        {
            try
            {
                _idUser = GetIdUserLogged();
                return Ok(await _playerTournamentsService.Put(id, contrato, _idUser));
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
                _idUser = GetIdUserLogged();
                await _playerTournamentsService.Inactivation(id, _idUser);
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