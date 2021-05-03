using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Models.ModelView
{
    public class Booking
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Field { get; set; }
        public int TraiNo { get; set; }
        public string NamePasser { get; set; }
        public int Age { get; set; }
        public int TotalChair { get; set; }

    }
}
