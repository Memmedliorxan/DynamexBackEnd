using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Interfaces;
using Data.DAL;

namespace Data.Repositories.Implementations
{
    public class CargoRepository :Repository<Cargo>, ICargoRepository
    {
    private readonly AppDbContext _context;
    public CargoRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    }
}
