using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Models.ModelView
{
    public class Bills
    {
        public int Id { get; set; }
        public string NamePass { get; set; }
        public int Age { get; set; }
        public bool Status { get; set; }
        public int PNRNO { get; set; }
        public int Price { get; set; }
        public int TrainNo { get; set; }
        public string  Field { get; set; }
        public DateTime Timefrom { get; set; }
        public int Seats { get; set; }
    }
}
