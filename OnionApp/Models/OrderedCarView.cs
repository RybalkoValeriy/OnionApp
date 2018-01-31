using CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace OnionApp.Models
{
    public class OrderedCarView
    {
        public Car Car { get; set; }
        public int Count { get; set; }
    }
}