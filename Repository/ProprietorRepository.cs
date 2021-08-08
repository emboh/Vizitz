using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vizitz.Data;
using Vizitz.Entities;
using Vizitz.Models.Paginate;
using X.PagedList;

namespace Vizitz.Repository
{
    public class ProprietorRepository : GenericRepository<User>
    {
        private readonly DatabaseContext _context;

        private readonly DbSet<User> _db;

        public ProprietorRepository(DatabaseContext context)
            : base(context)
        {
            _context = context;

            _db = _context.Set<User>();
        }

        public async new Task<User> Get(Expression<Func<User, bool>> expression, List<string> includes = null)
        {
            IQueryable<User> query = _db;

            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            query.Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role.Id == new Guid(Role.ProprietorId));

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public new async Task<IPagedList<User>> GetPagedList(RequestParams requestParams, List<string> includes = null)
        {
            IQueryable<User> query = _db;

            if (includes != null)
            {
                foreach (var includePropery in includes)
                {
                    query = query.Include(includePropery);
                }
            }

            query.Include(u => u.UserRoles.Where(r => r.RoleId == new Guid(Role.ProprietorId)))
                .ThenInclude(ur => ur.Role);

            return await query.AsNoTracking()
                .ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
        }
    }
}
