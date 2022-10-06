using AutoMapper;
using ArticleManager.Models.EditModels;
using ArticleManager.Models.Entities;
namespace ArticleManager.AutiMapping
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Article, CreateArticleEditModel>().ReverseMap();
            CreateMap<Article, EditArticleEditModel>().ReverseMap();

            CreateMap<ArticleArticle, CreateArticleArticleEditModel>().ReverseMap();
            CreateMap<ArticleArticle, EditArticleArticleEditModel>().ReverseMap();
        }
    }
}
