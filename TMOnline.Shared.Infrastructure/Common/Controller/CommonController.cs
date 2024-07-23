using Microsoft.AspNetCore.Mvc;

using TMOnline.Shared.Core.Exceptions;
using TMOnline.Shared.Infrastructure.Models;

namespace TMOnline.Shared.Infrastructure.Controller
{
    public abstract class CommonController : ControllerBase
    {
        protected IActionResult ReturnNotFound()
        {
            return StatusCode(404, new ApiResponseModel());
        }

        protected IActionResult ReturnFail(ValidationErrorException validationError)
        {
            return StatusCode(400, new ApiResponseModel(validationError.ErrorMessages));
        }

        protected IActionResult ReturnFail(FeatureException featureException)
        {
            if (featureException.ExceptionType == FeatureExceptionType.InvalidOperation)
            {
                return Conflict(new ApiResponseModel(featureException.ErrorMessages));
            }
            else
            {
                return StatusCode(500, new ApiResponseModel(featureException.ErrorMessages));
            }
        }

        protected IActionResult ReturnSuccess<TResponse>(TResponse response)
        {
            return this.Ok(new ApiResponseModel<TResponse>(response));
        }
    }
}
