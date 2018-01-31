using CoreEntities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnionApp.Models
{
    public class TransactionResultView
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<OrderedCarView> OrderedCars { get; set; }
    }
}