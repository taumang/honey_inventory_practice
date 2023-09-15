using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace honey_inventory_practice
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<HoneyInventory,GetHoneyInventoryDto>();
            CreateMap<AddHoneyInventoryDto,HoneyInventory>();
        }
    }
}