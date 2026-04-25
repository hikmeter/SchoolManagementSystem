using EOkul.Application.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace EOkul.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult CreateResponse<T>(ResponseDto<T> response) where T : class
        {
            if (response.isSuccess)
            {
                return Ok(response);
            }
            return response.ErrorCode switch
            {
                ErrorCode.NotFound => NotFound(response),
                ErrorCode.ValidationError => BadRequest(response),
                ErrorCode.Unauthorized => Unauthorized(response),
                ErrorCode.Forbidden => StatusCode(StatusCodes.Status403Forbidden, response),
                ErrorCode.Exception => StatusCode(StatusCodes.Status500InternalServerError, response),
                ErrorCode.DuplicateError => Conflict(response),
                ErrorCode.BadRequest => BadRequest(response),
                _ => BadRequest(response)
            };
        }
    }
}
