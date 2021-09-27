using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Backend.Domain.Shared.Entities;

namespace Backend.Domain.Entities
{
    public class Buy : Entity
    {
        private readonly IList<Product> _products;

        public Buy() {}
        public Buy(List<Product> products, DateTime dateTime)
        {
            DateTime = dateTime;
            _products = products;
        }

        public DateTime DateTime { get; private set; }
        public IReadOnlyCollection<Product> Products => _products == null ? new List<Product>() : _products.ToArray();
    }
}