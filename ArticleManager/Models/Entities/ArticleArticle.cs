using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleManager.Models.Entities
{
    public class ArticleArticle
    {
        [Key]
        public int ID { get; set; }
        public int SourceArticleID { get; set; }
        public int DestinationArticleID { get; set; }
        public string Description { get; set; } = "";
        public Article SourceArticle { get; set; }
        public Article DestinationArticle { get; set; }
    }
    public class ArticleArticleConfiguration : IEntityTypeConfiguration<ArticleArticle>
    {
        public void Configure(EntityTypeBuilder<ArticleArticle> builder)
        {
            builder.HasOne(a => a.SourceArticle).WithMany(aa => aa.Cites).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.DestinationArticle).WithMany(aa => aa.CitedBys).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
