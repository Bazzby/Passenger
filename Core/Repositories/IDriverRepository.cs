﻿using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface IDriverRepository
    {
        Driver Get(Guid userId);
        IEnumerable<Driver> GetAll();
        void Add(Driver driver);
        void Update(Driver driver);
    }
}