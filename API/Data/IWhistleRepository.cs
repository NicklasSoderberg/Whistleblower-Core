using API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public interface IWhistleRepository
    {
        // General
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // User


        // Whislte
        Task<Whistle[]> GetAllWhistles(bool getInActive = false);
        Task<Whistle> GetWhistle(int WhistleID);

        // Conversation
        Task<Conversation[]> GetConversation(int WhistleID);

        // File
    }
}
