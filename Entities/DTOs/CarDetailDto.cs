using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Descriptions { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public bool Status { get; set; }
        
    }
}
