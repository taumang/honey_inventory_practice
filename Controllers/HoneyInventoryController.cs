global using honey_inventory_practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using honey_inventory_practice.Services.HoneyInventoryService;
using Microsoft.AspNetCore.Mvc;

namespace honey_inventory_practice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HoneyInventoryController : ControllerBase
    {

        //Calling the Honey Inventory service in the bodies of the HTTP methods **
        //constructor
        private readonly IHoneyInventoryService _honeyInventoryService;
        public HoneyInventoryController(IHoneyInventoryService honeyInventoryService)
        {
            _honeyInventoryService = honeyInventoryService;

        }


        /*
            - Copy the HTTP-Get method into the next line
            - (GetAll) is for displaying all the records
        */
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetHoneyInventoryDto>>>> Get()
        {
            return Ok(await _honeyInventoryService.GetAllHoneyInventory());
        }

        //Get a one item from (GetAll)
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetHoneyInventoryDto>>> GetSingle(int id)// LINQ is used the find the ids.
        {
            /*
            - Lumda expressions are used here.= return Ok(honeyInventories.FirstOrDefault(hi => hi.Id == id));

            - Then the Lumbda expression falls = return Ok(_honeyInventoryService.GetHoneyInventoryId(id))
            */
            return Ok(await _honeyInventoryService.GetHoneyInventoryId(id));
        }
        //This is the body of the application
        //adding a new Honey product in the Inventory
        /*
            1.) honeyInventories.Add(newHoneyInventory);
            return Ok(honeyInventories);

            is now replaced by: 

            2.) return Ok(_honeyInventoryService.AddHoneyInventory(newHoneyInventory));

        */
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetHoneyInventoryDto>>>> AddHoneyInventory(AddHoneyInventoryDto newHoneyInventory)
        {
            return Ok(await _honeyInventoryService.AddHoneyInventory(newHoneyInventory));
        }

        //
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetHoneyInventoryDto>>>> UpdateHoneyInventory(UpdateHoneyInventoryDto updatedHoneyInventory)
        {
            var response = await _honeyInventoryService.UpdateHoneyInventory(updatedHoneyInventory);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetHoneyInventoryDto>>> DeleteHoneyInventory(int id)// LINQ is used the find the ids.
        {
            var response = await _honeyInventoryService.DeleteHoneyInventory(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}