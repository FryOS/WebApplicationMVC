using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationMVC.Models
{
    //[Table("MyRequest")]
    public class MyRequest
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
}
