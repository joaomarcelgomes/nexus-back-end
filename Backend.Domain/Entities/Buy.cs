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
        public Buy(User user, List<Product> products, DateTime dateTime)
        {
            UserId = user.Id;
            User = user;
            DateTime = dateTime;
            _products = products;
        }

        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public DateTime DateTime { get; private set; }
        public IReadOnlyCollection<Product> Products => _products == null ? new List<Product>() : _products.ToArray();
    }
}