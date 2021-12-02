using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApi.Core.Entities;
using WebApi.Core.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatillosController : ControllerBase
    {
        private readonly ILogger<PlatillosController> _logger;
        private readonly IPlatilloRepository _productRepository;

        public PlatillosController(ILogger<PlatillosController> logger, IPlatilloRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var products = await _productRepository.GetById(id);
            return Ok(products);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(Platillo product)
        {
            _ = await _productRepository.Insert(product);
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Platillo product)
        {
            var currentPlatillo = await _productRepository.GetById(product.Id);
            if (currentPlatillo == null)
            {
                return BadRequest("El platillo que desea actualizar no existe.");
            }

            _ = await _productRepository.Update(product);
            return Ok();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var currentPlatillo = await _productRepository.GetById(id);
            if (currentPlatillo == null)
            {
                return BadRequest("El platillo que desea eliminar no existe.");
            }

            _ = await _productRepository.Delete(id);
            return Ok();
        }
    }
}
