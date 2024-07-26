using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TMOnline.Feature.Product.Core.Queries;
using TMOnline.Shared.Infrastructure.Controller;

namespace TMOnline.Feature.Product.Web.Controllers
{
    [ApiController]
    [Route("/api/currencies")]
    internal class CurrenciesController : CommonController
    {
        private readonly IMediator _mediator;

        public CurrenciesController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

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
