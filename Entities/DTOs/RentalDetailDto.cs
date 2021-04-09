using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        //Customer Table
        public string CompanyName { get; set; }

        //User Table
        public string FirstName { get; set; }

        public string LastName { get; set; }

        //Brand Table
        public string BrandName { get; set; }

        //Color Table
        public string ColorName { get; set; }

        //Car Table
        public string CarDesctiption { get; set; }

        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
