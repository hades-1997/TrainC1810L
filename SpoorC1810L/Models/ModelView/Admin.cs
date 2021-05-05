
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Models.ModelView
{
    public class Admin
    {
        public int Id { get; set; }
        public string Namepass { get; set; }
        public int PNRno { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public int Total { get; set; }
        public int MoneyReceived { get; set; }
        public int Refunds { get; set; }
        public int TotalMoney { get; set; }
    }
}
