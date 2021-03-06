﻿using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Driver
    {
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        public IEnumerable<Route> Routes { get; protected set; }
        public IEnumerable<DailyRoute> DailyRoutes { get; protected set; }
        public DateTime UpdateAt { get; protected set; }

        protected Driver()
        {
        }

        public Driver(User user)
        {
            UserId = user.Id;
            Name = user.Username;
        }

        public void SetVehicle(string brand, string name, int seats)
        {
            Vehicle = Vehicle.Create(brand, name, seats);
            UpdateAt = DateTime.UtcNow;
        }
    }
}
