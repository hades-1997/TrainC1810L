using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainC1810L.Models;

namespace TrainC1810L.Interfaces
{
    interface IChair
    {
        //void Update();

        Task<bool> SaveAllAsync();

        Task<IEnumerable<Compartment>> GetCompartments();

        Task<Compartment> GetChairId(int id);

        //Task<Compartment> ();
    }
}
