using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WarehouseService: IWarehouseService
    {
        public bool CreateWarehouse()
        {
            return true;
        }

        public IList<WarehouseDTO> GetWarehouses() => new List<WarehouseDTO>()
            {
                new WarehouseDTO(){ WarehouseId=1, Name="Warehouse1" },
                new WarehouseDTO(){ WarehouseId=2, Name="Warehouse2" },
                new WarehouseDTO(){ WarehouseId=3, Name="Warehouse3" },

            };
    }
}
