﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkshopASPMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; }
        private ICollection<SalesRecord> Sales { get; set; } = new HashSet<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, double baseSalary, DateTime birthDate, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Department = department;
        }

        public void AddSales(SalesRecord sale) =>
            Sales.Add(sale);

        public void RemoveSales(SalesRecord sale) =>
            Sales.Remove(sale);

        public double TotalSales(DateTime initial, DateTime final) => 
            Sales.Where(x => x.Date >= initial && x.Date <= final).Sum(x => x.Amount);
    }
}
