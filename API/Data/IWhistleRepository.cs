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
        Task<Whistle> GetUserWhistle(Guid userId);

        Task<Whistle[]> GetLawyerWhistles(Guid LawyerId);

        // Conversation
        Task<Conversation[]> GetConversation(int WhistleID);

        // File
        Task<File[]> GetFiles(int WhistleID);

        // Subject
        Task<Subject[]> GetAllSubjects(bool getInActive = false);
        Task<Subject> GetSubject(int subjectID);

        // Lawyer
        Task<Lawyer[]> GetAllLawyers();

        Task<Lawyer> PutLawyer(Lawyer Lawyer);

        Task<Lawyer> GetLawyer(Guid LawyerId);
    }
}
