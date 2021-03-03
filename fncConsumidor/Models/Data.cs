
namespace fncConsumidor.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Data
    {
        [Key]
        public string NameDevice { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime EventDateTime { get; set; }
        [Required]
        public string Event { get; set; }

    }
}

