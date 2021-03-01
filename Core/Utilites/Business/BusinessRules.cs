using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilites.Results.Abstract;

namespace Core.Utilites.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    // başarısızsa 
                    return logic;
                }

            }
            return null;
        }
    }
}
