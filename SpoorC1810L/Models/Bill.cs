using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int MoneyReceived { get; set; }
        public int Refunds { get; set; }
        public int TotalMoney { get; set; }
        public BookingTicket bookingticket { get; set; }
        public int BookingTicketID { get; set; }
    }
}
