using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTO
{
    public class DriverDTO
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
