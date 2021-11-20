using System.Collections.Generic;
using System.Threading.Tasks;
using WebHookReceiver.Models;

namespace WebHookReceiver.Services
{
    public interface IGithubHandler
    {
        Task<bool> SaveCommit(Root commit);
        Task<IList<GitHubCommit>> ViewCommit();
    }
}
