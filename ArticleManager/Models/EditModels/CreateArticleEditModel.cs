using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleManager.Models.EditModels
{
    public class CreateArticleEditModel
    {
        [Required]
        public string Title { get; set; } = "";
        [Required]
        public string Link { get; set; } = "";
        public string FilePath { get; set; } = "";
        [Range(1950, int.MaxValue, ErrorMessage = "Published Year Must Be Grater Than 1950")]
        public int PublishedYear { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "CitationCountInGoogleScholar  Must Be Grater Than Zero")]
        public int CitationCountInGoogleScholar { get; set; }
    }
}
