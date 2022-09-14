using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Interfaces;
using Data.DAL;

namespace Data.Repositories.Implementations
{
    public class FilialRepository : Repository<Filial>, IFilialRepository
    {
        private readonly AppDbContext _context;
        public FilialRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
