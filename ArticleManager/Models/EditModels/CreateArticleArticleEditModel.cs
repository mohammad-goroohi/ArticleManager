using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleManager.Models.EditModels
{
    public class CreateArticleArticleEditModel
    {
        [Required]
        public int SourceArticleID { get; set; }
        [Required]
        public int DestinationArticleID { get; set; }
        public string Description { get; set; } = "";
        public int ReferenceNumberInSourceArticle { get; set; }
    }
}
