using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainC1810L.Interfaces;

namespace TrainC1810L.Data
{
    public class AjaxChair : IChair
    {
        private readonly ApplicationDbContext _context;

        public AjaxChair(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Models.Compartment> GetChairId(int id)
        {
            return await _context.compartments.FindAsync(id);
        }

        public Task<IEnumerable<Models.Compartment>> GetCompartments()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
