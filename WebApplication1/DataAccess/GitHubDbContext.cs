using Microsoft.EntityFrameworkCore;
using WebHookReceiver.Models;

namespace WebHookReceiver.DataAccess
{
    public class GitHubDbContext : DbContext
    {
        public DbSet<GitHubCommit> GitHubCommit { get; set; }
        public GitHubDbContext()
        {

        }

        public GitHubDbContext(DbContextOptions<GitHubDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {


        }
    }
}
