using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleManager.Models.EditModels
{
    public class EditArticleEditModel
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; } = "";
        public string ArticleDescription { get; set; } = "";
        public string MyDescription { get; set; } = "";
        [Required]
        public string Link { get; set; } = "";
        public string FilePath { get; set; } = "";
        public bool IsRead { get; set; } = false;
    }
}
