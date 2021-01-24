namespace MyPersonalPage.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task CreateAsync(string username, string content, string creatorId);

        IEnumerable<T> GetLatestComments<T>();

        IEnumerable<T> GetAllWithMyUsername<T>(string username);
    }
}
