using COLORADO.Data.FrontDTO;
using COLORADO.Data.Models;
using COLORADO.Services;
using Microsoft.AspNetCore.Mvc;

namespace COLORADO.Data.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    IOrderInterface orderInterface;
    public OrderController(IOrderInterface orderInterface)
    {
        this.orderInterface = orderInterface;
    }
    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetAllOrders()
    {
        return Ok(await orderInterface.GetAllOrders());
    }

    [HttpGet("{userId}/Orders")]
    public async Task<ActionResult<List<IGrouping<long, Order>>>> GetAllUserOrders(int userId)
    {
        var result = await orderInterface.GetAllUserOrders(userId);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpGet("{userId}/Last_Order")]
    public async Task<ActionResult<IGrouping<long, Order>>> GetLastUserOrder(int userId)
    {
        var result = await orderInterface.GetLastUserOrder(userId);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }


    [HttpGet("{transactionId}")]
    public async Task<ActionResult<List<Order>>> GetOrder(int transactionId)
    {
        var result = await orderInterface.GetOrder(transactionId);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<List<Order>>> AddOrder(int id, OrderFromFront orders)
    {
        return Ok(await orderInterface.AddOrder(id, orders));
    }

}

