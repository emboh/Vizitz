using System;
using System.Threading.Tasks;
using Vizitz.Entities;

namespace Vizitz.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Schedule> Schedules { get; }

        IGenericRepository<User> Users { get; }

        IGenericRepository<Venue> Venues { get; }

        IGenericRepository<Visit> Visits { get; }

        Task Save();
    }
}
