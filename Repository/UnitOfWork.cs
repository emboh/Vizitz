using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vizitz.Data;
using Vizitz.Entities;
using Vizitz.IRepository;

namespace Vizitz.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        private bool _disposedValue;

        private IGenericRepository<Schedule> _schedules;

        private IGenericRepository<User> _users;

        private IGenericRepository<Venue> _venues;

        private IGenericRepository<Visit> _visits;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IGenericRepository<Schedule> Schedules => _schedules ??= new GenericRepository<Schedule>(_context);

        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);

        public IGenericRepository<Venue> Venues => _venues ??= new GenericRepository<Venue>(_context);

        public IGenericRepository<Visit> Visits => _visits ??= new GenericRepository<Visit>(_context);

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~UnitOfWork()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
