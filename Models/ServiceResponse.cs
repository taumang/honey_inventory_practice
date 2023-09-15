using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace honey_inventory_practice.Models
{
    public class ServiceResponse<T>// type of data I want to return
    {
        public T? Data{ get; set; } // The actual
        public bool Success { get; set; } // sends a success message to the frontend
        public string Message { get; set; } = string.Empty;// sends a response to possible errors/exceptions which might occur
    }
}