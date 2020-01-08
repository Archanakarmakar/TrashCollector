using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string StreetAddress { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public int ZipCode { get; set; }
        public double Balance { get; set; }

        [DisplayName("Select your pickup day")]
        public string WeeklyPickupDay { get; set; }
        public bool PickupCompleted { get; set; }
        public string OneTimePickupDate { get; set; }
        public string SuspendPickupStart { get; set; }
        public string SuspendPickupStop { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}

