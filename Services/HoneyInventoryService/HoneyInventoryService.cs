using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace honey_inventory_practice.Services.HoneyInventoryService
{
    public class HoneyInventoryService : IHoneyInventoryService
    {
        // errors are fixed using AutoMapper dependency
        private static List<HoneyInventory> honeyInventories = new List<HoneyInventory>{
            new HoneyInventory(),
            new HoneyInventory {
                Id = 1,
                UnitNumber = "Number12"
                }
        };

        //constructor of the automapper
        private readonly IMapper _mapper;
        public HoneyInventoryService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetHoneyInventoryDto>>> AddHoneyInventory(AddHoneyInventoryDto newHoneyInventory)
        {
            var serviceResponse = new ServiceResponse<List<GetHoneyInventoryDto>>();
            var honeyInventory = _mapper.Map<HoneyInventory>(newHoneyInventory);
            honeyInventory.Id = honeyInventories.Max(hi=> hi.Id) + 1;
            honeyInventories.Add(honeyInventory);
            serviceResponse.Data = honeyInventories.Select(hi =>_mapper.Map<GetHoneyInventoryDto>(hi)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetHoneyInventoryDto>>> DeleteHoneyInventory(int id)
        {
            
            var serviceResponse = new ServiceResponse<List<GetHoneyInventoryDto>>();
            try
            {
            var honeyInventory = honeyInventories.FirstOrDefault(hi => hi.Id == id);
            if(honeyInventory is null)
                    throw new Exception($"Honey Product with Id '{id}' is not found in the list, sorry!");

            
            honeyInventories.Remove(honeyInventory);
            serviceResponse.Data = honeyInventories.Select(hi=>_mapper.Map<GetHoneyInventoryDto>(hi)).ToList();
            }
            catch (Exception ex)
            {
                
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetHoneyInventoryDto>>> GetAllHoneyInventory()
        {
            var serviceResponse = new ServiceResponse<List<GetHoneyInventoryDto>>();
            serviceResponse.Data = honeyInventories.Select(hi=>_mapper.Map<GetHoneyInventoryDto>(hi)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetHoneyInventoryDto>> GetHoneyInventoryId(int id)
        {
            var serviceResponse = new ServiceResponse<GetHoneyInventoryDto>();
            var honeyInventory = honeyInventories.FirstOrDefault(hi => hi.Id == id);
            serviceResponse.Data = _mapper.Map<GetHoneyInventoryDto>(honeyInventory);//AutoMapper Implemented in the Get ID
            return serviceResponse;
        }


        public async Task<ServiceResponse<GetHoneyInventoryDto>> UpdateHoneyInventory(UpdateHoneyInventoryDto updatedHoneyInventory)
        {
            var serviceResponse = new ServiceResponse<GetHoneyInventoryDto>();
            
            try
            {
            var honeyInventory = honeyInventories.FirstOrDefault(hi => hi.Id == updatedHoneyInventory.Id);
            if(honeyInventory is null)
                    throw new Exception($"Honey Product with Id '{updatedHoneyInventory.Id}' is not found in the list, sorry!");

            /*
               1- _mapper.Map<HoneyInventory>(updatedHoneyInventory);
               2- _mapper.Map(UpdatedHoneyInventory,honeyInventory); (another CreateMap will need to be added in the project)
            */
            

            honeyInventory.UnitNumber = updatedHoneyInventory.UnitNumber;
            honeyInventory.TypeClass = updatedHoneyInventory.TypeClass;
            honeyInventory.Honey_Size = updatedHoneyInventory.Honey_Size;
            honeyInventory.Honey_Color = updatedHoneyInventory.Honey_Color;
            honeyInventory.PriceClass = updatedHoneyInventory.PriceClass;
            honeyInventory.Number_of_Bottles = updatedHoneyInventory.Number_of_Bottles;

            serviceResponse.Data = _mapper.Map<GetHoneyInventoryDto>(honeyInventory);
            }
            catch (Exception ex)
            {
                
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

// The code snippet defines a class called HoneyInventoryService that implements an interface called IHoneyInventoryService. It contains methods for adding, getting, and updating honey inventory items. The methods use AutoMapper to map between different data transfer objects (DTOs) and
            return serviceResponse;
        }
    }


}