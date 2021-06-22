using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TruckRegister.Entities;
using TruckRegister.Repository.Interface;

namespace TruckRegister.Repository
{
    public class TruckRepository : ITruckRepository
    {
        private readonly TruckContext _context;
        public TruckRepository(TruckContext context)
        {
            _context = context;
        }

        public async Task<Truck> GetById(Guid id) =>
            await _context.Truck
                          .AsNoTracking()
                          .Include(m => m.ModelTruck)
                          .FirstOrDefaultAsync(t => t.Id.Equals(id));

        public async Task Save(Truck model)
        {
            await _context.Truck.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Truck model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Truck model)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
