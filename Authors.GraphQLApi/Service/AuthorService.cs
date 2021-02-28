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
            return _db.Authors.Include(c=>c.Books).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<Author>> GetAllAsync()
        {
            return _db.Authors.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAuthorBooksAsync(int authorId)
        {
            return await _db.Book.Where(c => c.AuthorId == authorId).ToListAsync();
        }


        public async Task<ILookup<int, Book>> GetAuthorBooksAsync(IEnumerable<int> authorIds)
        {
            var reviews = await _db.Book.Where(pr => authorIds.Contains(pr.AuthorId)).ToListAsync();
            return reviews.ToLookup(r => r.AuthorId);
        }

        public async Task<Author> AddAuthor(Author author)
        {
            _db.Authors.Add(author);
            await _db.SaveChangesAsync();
            return author;
        }
    }
}
