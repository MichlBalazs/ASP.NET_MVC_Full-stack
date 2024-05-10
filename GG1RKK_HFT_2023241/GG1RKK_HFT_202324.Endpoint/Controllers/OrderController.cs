using GG1RKK_HFT_202324.Endpoint.Services;
using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace GG1RKK_HFT_202324.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderLogic logic;
        IHubContext<SignalRHub> hub;
        public OrderController(IOrderLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Order> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Order Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Order value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("OrderCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Order value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("OrderUpdated", value);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deletedOrder = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("OrderDeleted", deletedOrder);
        }



        [HttpGet("OrderCount")]
        public int OrderCount(int AdventurerId)
        {
            return this.logic.OrderCount(AdventurerId);
        }

        [HttpGet("OrderedItemsCategory")]
        public int OrderedItemsCategory(int OrderId)
        {
            return this.logic.OrderedItemsCategory(OrderId);
        }
        [HttpGet("OrderedItemsAvgPrice")]
        public double OrderedItemsAvgPrice()
        {
            return this.logic.OrderedItemsAvgPrice();
        }
        [HttpGet("WhoBoughtThisItem")]
        public string WhoBoughtThisItem(int itemId)
        {
            return this.logic.WhoBoughtThisItem(itemId);
        }
    }
}
