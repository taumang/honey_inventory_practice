using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using honey_inventory_practice.Data;

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
        private readonly DataContext _context;
        public HoneyInventoryService(IMapper mapper,DataContext context )
        {
            _context = context;
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
            var dbHoneyInventories = await _context.HoneyInventories.ToListAsync();
            serviceResponse.Data = dbHoneyInventories.Select(hi=>_mapper.Map<GetHoneyInventoryDto>(hi)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetHoneyInventoryDto>> GetHoneyInventoryId(int id)
        {
            var serviceResponse = new ServiceResponse<GetHoneyInventoryDto>();
            var dbHoneyInventory = await _context.HoneyInventories.FirstOrDefaultAsync(hi => hi.Id == id);
            serviceResponse.Data = _mapper.Map<GetHoneyInventoryDto>(dbHoneyInventory);//AutoMapper Implemented in the Get ID
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


            return serviceResponse;
        }
    }


}