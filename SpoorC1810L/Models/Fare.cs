using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Models
{
    public class Fare
    {

        [Key]
        public int Id { get; set; }
        public int Distance { get; set; }
        public int TypeOfCompartment { get; set; }
        public int TypeOfTrain { get; set; }
    }
}



