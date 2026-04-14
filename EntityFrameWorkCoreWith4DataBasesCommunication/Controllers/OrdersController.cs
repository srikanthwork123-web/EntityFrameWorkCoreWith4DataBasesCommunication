using EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _orderService;
        public OrdersController(IOrdersService orderService)
        {
            _orderService= orderService;
        }
        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> Post([FromBody] OrdersDto orderdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var orderData = await _orderService.AddOrder(orderdto);
                    return StatusCode(StatusCodes.Status201Created, orderData);
                }
            }
            catch (Exception ex)
            {//if you got any error we are using this statuscode:Status500InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpDelete]
        [Route("DeleteOrderByOrderid/{orderid}")]
        public async Task<IActionResult> delete(int orderid)
        {
            if (orderid < 0)
            {//If input parameters are wrongly sent or empty, we will get 400 badrequest statuscode:Status400BadRequest
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var orderData = await _orderService.DeleteOrderById(orderid);

                if (orderData == null)
                {//in db if you get empty data we need to retrun this statuscode:Status404NotFound
                    return StatusCode(StatusCodes.Status404NotFound, "orderData not  found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet]
        [Route("GetOrders")]
        public async Task<IActionResult> GetOrder()
        {
            try
            {
                var orderdata = await _orderService.GetOrders();
                if (orderdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, orderdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }

        }
        [HttpGet]
        [Route("GetOrderByOrderid/{orderid}")]
        public async Task<IActionResult> Get(int orderid)
        {
            if (orderid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var orderdata = await _orderService.GetOrderById(orderid);
                return StatusCode(StatusCodes.Status200OK, orderdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server eror");
            }
        }
        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<IActionResult> put([FromBody] OrdersDto orderdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var orderData = await _orderService.UpdateOrder(orderdto);
                    return StatusCode(StatusCodes.Status200OK, orderData);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
    }
}
