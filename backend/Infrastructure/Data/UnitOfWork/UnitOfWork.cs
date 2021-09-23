using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Infrastructure.Data.Context;

namespace Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly StudentContext _context;

        public UnitOfWork(StudentContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            var changeAmount = await _context.SaveChangesAsync();

            return changeAmount == 1;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
