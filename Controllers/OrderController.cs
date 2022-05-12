using AngEcommerceProject.Dto;
using AngEcommerceProject.Repositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AngEcommerceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderProductRepository _OrderProduct;
        private readonly IOrderRepository _Order;

        public OrderController(IOrderProductRepository orderProduct , IOrderRepository order)
        {
            this._Order = order;
            this._OrderProduct = orderProduct;
        }
        [HttpGet("detail")]
        public IActionResult getOrder(int id)
        {
            var result = _OrderProduct.getOrderDetails(id);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }
        [HttpPost]
        public IActionResult postOrde([FromBody]List<ProductsCartDto> list)
        {
            return Ok();
        }

    }
}
