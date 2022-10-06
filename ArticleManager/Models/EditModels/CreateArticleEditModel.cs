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
    }
}
