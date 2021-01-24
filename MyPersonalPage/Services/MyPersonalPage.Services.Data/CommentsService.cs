namespace MyPersonalPage.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyPersonalPage.Data.Common.Repositories;
    using MyPersonalPage.Data.Models;
    using MyPersonalPage.Services.Data.Interfaces;
    using MyPersonalPage.Services.Mapping;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task CreateAsync(string username, string content, string creatorId)
        {
            var comment = new Comment
            {
                Username = username,
                Content = content,
                CreatorId = creatorId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllWithMyUsername<T>(string username)
        {
            IQueryable<Comment> comments = this.commentsRepository.All()
                .Where(x => x.Username == username)
                .OrderByDescending(x => x.CreatedOn);

            return comments.To<T>().ToList();
        }

        public IEnumerable<T> GetLatestComments<T>()
        {
            IQueryable<Comment> comments = this.commentsRepository.All()
                .OrderByDescending(x => x.CreatedOn).
                Take(10);

            return comments.To<T>().ToList();
        }
    }
}
