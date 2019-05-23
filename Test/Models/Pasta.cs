using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Pasta
    {
        public int ID { get; set; }
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }
        public string Hash { get; set; }
    }
}