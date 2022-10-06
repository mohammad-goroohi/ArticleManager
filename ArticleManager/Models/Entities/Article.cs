using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleManager.Models.Entities
{
    public class Article
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; } = "";
        public string ArticleDescription { get; set; } = "";
        public string MyDescription { get; set; } = "";
        public string Link { get; set; } = "";
        public string FilePath { get; set; } = "";
        public bool IsRead { get; set; } = false;
        public List<ArticleArticle> CitedBys { get; set; }
        public List<ArticleArticle> Cites { get; set; }
    }
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasIndex(a => a.Link).IsUnique();
            builder.HasMany(a => a.Cites).WithOne(aa => aa.SourceArticle);
            builder.HasMany(a => a.CitedBys).WithOne(aa => aa.DestinationArticle);
        }
    }
}
