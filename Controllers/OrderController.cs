using AngEcommerceProject.Dto;
using AngEcommerceProject.Models;
using AngEcommerceProject.Repositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                var order = new Order();
                var responseMessage = new OrderMessage { IsOk = false, productsFailed = new List<string>() };
                order = this._Order.create(order);
                foreach (var item in list)
                {
                    var newOrPro = new OrderProducts
                    {
                        OrderId = order.Id,
                        ProductId = item.iD,
                        ProductQuantity = item.iD,
                        ProductTotalPrice = item.price * item.quantity

                    };
                    var res = this._OrderProduct.create(newOrPro);
                    if (res == null)
                    {
                        responseMessage.productsFailed.Add(item.name);
                    }
                }
                return Ok(responseMessage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }

    }
}
