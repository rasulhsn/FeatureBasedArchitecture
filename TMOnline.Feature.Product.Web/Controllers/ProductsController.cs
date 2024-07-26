using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TMOnline.Feature.Product.Core.Commands;
using TMOnline.Feature.Product.Core.Queries;
using TMOnline.Shared.Core.Exceptions;
using TMOnline.Shared.Infrastructure.Controller;

namespace TMOnline.Feature.Product.Web.Controllers
{
    [ApiController]
    [Route("/api/products")]
    internal class ProductsController : CommonController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

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

        /// <summary>
        /// Get products by yearId
        /// </summary>
        [HttpGet("transaction-years/{yearId}")]
        public async Task<IActionResult> GetAllByYearAsync(int yearId)
        {
            Trace.TraceInformation($"{nameof(ProductsController)}/{nameof(GetAllByYearAsync)}({yearId})");

            var products = await _mediator.Send(new GetAllProductsByYearQuery(yearId));

            return ReturnSuccess(products);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            Trace.TraceInformation($"{nameof(ProductsController)}/{nameof(GetProductAsync)}({id})");

            var product = await _mediator.Send(new GetProductByIdQuery(id));

            if (product == null)
            {
                Trace.TraceWarning($"Product with id {id} not found");
                return ReturnNotFound();
            }

            return ReturnSuccess(product);
        }

        /// <summary>
        /// Add new product
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(AddProductCommand addProductCommand)
        {
            Trace.TraceInformation($"{nameof(ProductsController)}/{nameof(AddProductAsync)}(addProductCommand)");

            try
            {
                var product = await _mediator.Send(addProductCommand);
                return this.ReturnSuccess(product);
            }
            catch (ValidationErrorException exp)
            {
                return this.ReturnFail(exp);
            }
            catch(FeatureException exp)
            {
                return this.ReturnFail(exp);
            }
        }
    }
}
