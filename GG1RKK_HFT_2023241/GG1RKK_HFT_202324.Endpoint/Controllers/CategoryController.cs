using GG1RKK_HFT_202324.Endpoint.Services;
using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GG1RKK_HFT_202324.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryLogic logic;
        IHubContext<SignalRHub> hub;

        public CategoryController(ICategoryLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Category> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Category Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void CreateCategory([FromBody] Category value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("CategoryCreated", value);
        }

        [HttpPut]
        public void UpdateCategory([FromBody] Category value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("CategoryUpdated", value);
        }

        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            var deletedCategory = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("CategoryDeleted", deletedCategory);
        }


        [HttpGet("GetItemsNumberInCategory")]
        public int GetItemsNumberInCategory(string category)
        {
            return this.logic.GetItemsNumberInCategory(category);
        }
    }
}
