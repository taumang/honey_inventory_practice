using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace honey_inventory_practice.Dtos.InventoryHoney
{
    public class UpdateHoneyInventoryDto
    {
        public int Id { get; set; }
       public string UnitNumber { get; set; } = "Number12";
        public HoneyTypeClass TypeClass { get; set; } = HoneyTypeClass.Multifolra_Honey;
        public string Honey_Size { get; set; } = "357g";
        public string Honey_Color { get; set; } = "Dark";
        public HoneyPriceClass PriceClass { get; set; } = HoneyPriceClass.R53;
        public int Number_of_Bottles { get; set; } = 45;
    }
}