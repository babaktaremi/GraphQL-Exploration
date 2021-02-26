using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authors.GraphQLApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Authors.GraphQLApi.Service
{
    public class AuthorService
    {
        private readonly ApplicationDbContext _db;

        public AuthorService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<Author> GetOneAsync(int id)
        {
            return _db.Authors.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<Author>> GetAllAsync()
        {
            return _db.Authors.ToListAsync();
        }
    }
}
