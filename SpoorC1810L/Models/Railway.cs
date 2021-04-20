using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpoorC1810L.Models
{
    
    public class Railway
    {
        public int Id { get; set; }
        public string RailwayName { get; set; }
        public ICollection<Station> stations { get; set; }

    }
}
