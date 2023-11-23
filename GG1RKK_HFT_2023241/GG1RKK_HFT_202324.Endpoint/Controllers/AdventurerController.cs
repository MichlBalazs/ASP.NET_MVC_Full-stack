using GG1RKK_HFT_2023241.Logic.Interfaces;
using GG1RKK_HFT_2023241.Repository.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GG1RKK_HFT_202324.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdventurerController : ControllerBase
    {
        IAdventurerLogic logic;

        public AdventurerController(IAdventurerLogic logic)
        {
            this.logic = logic;
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

        // POST api/<AdventurerController>
        [HttpPost]
        public void Create([FromBody] Adventurer adventurer)
        {
            logic.Create(adventurer);
        }

        // PUT api/<AdventurerController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Adventurer adventurer)
        {
            logic.Update(adventurer);
        }

        // DELETE api/<AdventurerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
