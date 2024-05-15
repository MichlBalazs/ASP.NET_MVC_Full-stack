using GG1RKK_HFT_202324.Endpoint.Services;
using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Logic.Interfaces;
using GG1RKK_HFT_2023241.Repository.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GG1RKK_HFT_202324.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdventurerController : ControllerBase
    {
        IAdventurerLogic logic;
        IHubContext<SignalRHub> hub;

        public AdventurerController(IAdventurerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Adventurer> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<AdventurerController>/5
        [HttpGet("{id}")]
        public Adventurer Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Adventurer value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("ItemCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Adventurer value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("ItemUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deletedAdventurer = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("ItemDeleted", deletedAdventurer);
        }
    }
}
