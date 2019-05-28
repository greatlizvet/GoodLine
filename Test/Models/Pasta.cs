using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Pasta
    {
        public int ID { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string Text { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }
        public string Hash { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EndTime { get; set; }
    }
}