using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Interfaces;
using Data.DAL;

namespace Data.Repositories.Implementations
{
    public class AddressesRepository : Repository<Addresses>, IAddressesRepository
    {
        private readonly AppDbContext _context;
        public AddressesRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
