﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilites.Results.Abstract;

namespace Core.Utilites.Results.Concrete
{ 
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
