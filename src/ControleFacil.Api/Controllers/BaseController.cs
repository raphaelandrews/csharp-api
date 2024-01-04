using System.Security.Claims;
using ControleFacil.Api.Contract;
using Microsoft.AspNetCore.Mvc;

namespace ControleFacil.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected long _idUser; 
        protected long GetIdUserLogged()
        {
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            long.TryParse(id, out long idUser);

            return idUser;
        }

        protected ModelErrorContract ReturnModelBadRequest(Exception ex)
        {
            return new ModelErrorContract {
                Status = 400,
                Title = "Bad Request",
                Message = ex.Message,
                DateTime = DateTime.Now
            };
        }

        protected ModelErrorContract ReturnModelNotFound(Exception ex)
        {
            return new ModelErrorContract {
                Status = 404,
                Title = "Not Found",
                Message = ex.Message,
                DateTime = DateTime.Now
            };
        }

        protected ModelErrorContract ReturnModelUnauthorized(Exception ex)
        {
            return new ModelErrorContract {
                Status = 401,
                Title = "Unauthorized",
                Message = ex.Message,
                DateTime = DateTime.Now
            };
        }        
    }
}