﻿using AspNet_Api_EfCore.Interfaces;

namespace AspNet_Api_EfCore.ValueObject
{
    public class RequestId : IRequestId
    {
        public int Id { get; set; }
    }
}
