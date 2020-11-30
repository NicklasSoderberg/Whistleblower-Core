using API.Data.Entities;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class WhistleRepository : IWhistleRepository
    {
        private readonly IdentityContext _context;

        public ILogger<WhistleRepository> _logger;
        private readonly LinkGenerator _linkGenerator;

        public WhistleRepository(IdentityContext context, ILogger<WhistleRepository> logger, LinkGenerator linkGenerator)
        {
            _context = context;
            _logger = logger;
            _linkGenerator = linkGenerator;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Whistle[]> GetAllWhistles(bool getInActive = false)
        {
            IQueryable<Whistle> query = _context.Whistles.Where(c => c.WhistleID == c.WhistleID);
            return await query.ToArrayAsync();
        }

        public async Task<Conversation[]> GetConversation(int WhistleID)
        {
            IQueryable<Conversation> query = _context.Conversations.Where(c => c.WhistleID == WhistleID);
            return await query.ToArrayAsync();
        }

        public async Task<Whistle> GetWhistle(int WhistleID)
        {
            IQueryable<Whistle> query = _context.Whistles.Where(c => c.WhistleID == WhistleID);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<File[]> GetFiles(int WhistleID)
        {
            IQueryable<File> query = _context.Files.Where(c => c.WhistleID == WhistleID);
            return await query.ToArrayAsync();
        }
        public async Task<Whistle> GetUserWhistle(Guid userId)
        {
            IQueryable<Whistle> query = _context.Whistles.Where(c => c.UserID == userId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
