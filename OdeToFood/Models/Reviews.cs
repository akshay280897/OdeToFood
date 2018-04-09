using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Body { get; set; }

        [Range(1,10) ]
        [Required]
        public int Rating { get; set; }
        [Required]
      
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }
       
    }
}