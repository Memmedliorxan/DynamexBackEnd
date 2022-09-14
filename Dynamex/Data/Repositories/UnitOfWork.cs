using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Interfaces;
using Data.DAL;
using Data.Repositories.Implementations;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        private ICityRepository _cityRepository;
        private IFilialRepository _filialRepository;
        private ICargoRepository _cargoRepository;
        private IAddressesRepository _addressesRepository;
        private IOrderRepository _orderRepository;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ICityRepository cityRepository => _cityRepository = _cityRepository ?? new CityRepository(_context);
        public IFilialRepository filialRepository => _filialRepository = _filialRepository ?? new FilialRepository(_context);
        public ICargoRepository cargoRepository => _cargoRepository = _cargoRepository ?? new CargoRepository(_context);
        public IAddressesRepository addressesRepository => _addressesRepository = _addressesRepository ?? new AddressesRepository(_context);
        public IOrderRepository orderRepository => _orderRepository = _orderRepository ?? new OrderRepository(_context);


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
