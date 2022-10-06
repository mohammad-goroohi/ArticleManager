using ArticleManager.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArticleManager.Models
{
    public class ArticleManagerContext:DbContext
    {
        public ArticleManagerContext(DbContextOptions<ArticleManagerContext> option):base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleArticleConfiguration());
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleArticle> ArticleArticles { get; set; }
    }
}