﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Interface
{
    public interface IProductRepository : IDisposable
    {
        void Create(Products instance);

        void Update(Products instance);

        void Delete(Products instance);

        Products Get(int productID);

        IQueryable<Products> GetAll();

        void SaveChanges();
    }
}