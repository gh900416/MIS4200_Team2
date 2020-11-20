using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200_Team2.Models
{
    public class Recognition
    {
        public int ID { get; set; }
        
        [Display(Name ="Core Value Being Recognized")]
        public CoreValue award { get; set; }
        [Display(Name = "Who's giving the recognition?")]
        public Guid recognizer { get; set; }

        [Display(Name = "Receiver of recognition")]
        public Guid recognized { get; set; }

        [Display(Name = "Date recognition given")]
        public DateTime recognizationDate { get; set; }

        public enum CoreValue
        {
            Stewardship = 1,
            Culture = 2,
            Innovation = 3,
            Integrity = 4,
            Delivery = 5,
            GreaterGood = 6,
            Balance = 7
        }




    }
}