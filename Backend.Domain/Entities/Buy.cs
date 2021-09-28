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
        public Buy(User user, IList<Product> products, DateTime dateTime)
        {
            UserId = user.Id;
            User = user;
            DateTime = dateTime;
            _products = products;
        }

        public Guid UserId { get; }
        public User User { get; }
        public DateTime DateTime { get; }
        public IReadOnlyCollection<Product> Products => _products == null ? new List<Product>() : _products.ToArray();
    }
}