using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core
{
    public interface IUnitOfWork
    {
        public ICityRepository cityRepository { get; }
        public ICargoRepository cargoRepository { get; }
        public IAddressesRepository addressesRepository { get; }
        public IFilialRepository filialRepository { get; }
        public IOrderRepository orderRepository { get; }
        Task SaveAsync();
    }
}
