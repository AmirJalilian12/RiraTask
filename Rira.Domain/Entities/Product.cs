﻿namespace Rira.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Categories Category { get; set; }
    }
}
