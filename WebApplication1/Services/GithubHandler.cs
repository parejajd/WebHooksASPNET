using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebHookReceiver.DataAccess;
using WebHookReceiver.Models;

namespace WebHookReceiver.Services
{
    public class GithubHandler : IGithubHandler
    {
        private readonly GitHubDbContext _db;
        public GithubHandler(GitHubDbContext db)
        {
            _db = db;
        }
        public async Task<bool> SaveCommit(Root commit)
        {
            _db.Add<GitHubCommit>(new GitHubCommit
            {
                Developer = commit.head_commit.author.name,
                Message = commit.commits[0].message
            });
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IList<GitHubCommit>> ViewCommit()
        {
            var list = await _db.GitHubCommit.ToListAsync();
            return list;
        }
    }
}
