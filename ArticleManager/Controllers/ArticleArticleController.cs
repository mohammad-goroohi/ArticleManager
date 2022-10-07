using ArticleManager.Models;
using ArticleManager.Models.EditModels;
using ArticleManager.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleManager.Controllers
{
    public class ArticleArticleController : Controller
    {
        private readonly ArticleManagerContext _context;
        private readonly IMapper _mapper;
        public ArticleArticleController(ArticleManagerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ArticleArticle articleArticle = await _context.ArticleArticles.SingleOrDefaultAsync(aa=>aa.ID==id);
            if (articleArticle==null)
            {
                return BadRequest();
            }

            EditArticleArticleEditModel model = _mapper.Map<EditArticleArticleEditModel>(articleArticle);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditArticleArticleEditModel model)
        {
            if (ModelState.IsValid)
            {
                ArticleArticle articleArticle = await _context.ArticleArticles.SingleOrDefaultAsync(aa => aa.ID == model.ID);
                if (articleArticle == null)
                {
                    return BadRequest();
                }
                articleArticle = _mapper.Map(model, articleArticle);
                _context.Entry(articleArticle).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Redirect("/Article/Cites?id=" + articleArticle.SourceArticleID);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ArticleArticle articleArticle = await _context.ArticleArticles.SingleOrDefaultAsync(aa=>aa.ID==id);
            _context.ArticleArticles.Remove(articleArticle);
            await _context.SaveChangesAsync();
            return Redirect("/Article/Cites?id="+articleArticle.SourceArticleID);
        }
    }
}
