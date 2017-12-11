using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmarilloGearCompany.Models
{
    public class DriveCard
    {
        public string Model { get; set; }
        public string Ratio { get; set; }
        [Key]
        public string DriveNumber { get; set; }
        public string GearNumber { get; set; }

        //I'm not sure about how to do this. 
        public List<string> Models = new List<string> { "F85", "F110", "F135", "F155", "F175" };
    }
}
