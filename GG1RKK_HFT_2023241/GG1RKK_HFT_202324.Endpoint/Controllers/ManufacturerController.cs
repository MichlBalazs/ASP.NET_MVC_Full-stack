using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GG1RKK_HFT_202324.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        IManufacturerLogic logic;

        public ManufacturerController(IManufacturerLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Manufacturer> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Manufacturer Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Manufacturer value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Manufacturer value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
