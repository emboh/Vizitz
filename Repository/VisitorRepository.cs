using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vizitz.Data;
using Vizitz.Entities;
using Vizitz.Models.Paginate;
using X.PagedList;

namespace Vizitz.Repository
{
    public class VisitorRepository : GenericRepository<User>
    {
        private readonly DatabaseContext _context;

        private readonly DbSet<User> _db;

        public VisitorRepository(DatabaseContext context)
            : base(context)
        {
            _context = context;

            _db = _context.Set<User>();
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

            query.Include(u => u.UserRoles.Where(r => r.RoleId == new Guid(Role.VisitorId)))
                .ThenInclude(ur => ur.Role);

            return await query.AsNoTracking()
                .ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
        }
    }
}
