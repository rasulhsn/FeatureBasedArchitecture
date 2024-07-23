using Microsoft.AspNetCore.Mvc;

namespace TMOnline.Feature.Product.Web.Controllers
{
    [ApiController]
    [Route("/api/currencies")]
    internal class CurrenciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CurrenciesController(IMediator mediator)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Get all products
        /// </summary>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            Trace.TraceInformation($"{nameof(ProductsController)}/{nameof(GetAllAsync)}()");

            var products = await _mediator.Send(new GetAllProductsQuery());
            return ReturnSuccess(products);
        }
    }
}
