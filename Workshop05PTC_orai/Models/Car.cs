using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop05PTC_orai.Models
{
    public class Car {
        [Key]
        public string Id { get; set; }
        public string Type { get; set; }

        public int Price { get; set; }
        public string? ImageFileName { get; set; }
        public string? ContentType { get; set; }
        public byte[]? Data { get; set; }

        public Car()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

