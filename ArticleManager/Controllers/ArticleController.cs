using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleManager.Models.EditModels;
using ArticleManager.Models.Entities;
using ArticleManager.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ArticleManager.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ArticleManagerContext _context;
        private readonly IMapper _mapper;
        public ArticleController(ArticleManagerContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Articles()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleEditModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _context.Articles.AnyAsync(a=>a.Link==model.Link))
                {
                    ModelState.AddModelError("", "Another Article With This Link Are Exist.");
                    return View(model);
                }
                Article article = _mapper.Map<Article>(model);
                await _context.Articles.AddAsync(article);
                await _context.SaveChangesAsync();
                return RedirectToAction("Articles");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Article article = await _context.Articles.SingleOrDefaultAsync(a => a.ID == id);
            if (article==null)
            {
                return BadRequest();
            }
            EditArticleEditModel model = _mapper.Map<EditArticleEditModel>(article);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditArticleEditModel model)
        {
            if (ModelState.IsValid)
            {
                Article article = await _context.Articles.SingleOrDefaultAsync(a => a.ID == model.ID);
                if (article == null)
                {
                    return BadRequest();
                }
                article=_mapper.Map(model, article);
                _context.Entry(article).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Articles");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Article article =await _context.Articles.SingleOrDefaultAsync(a=>a.ID==id);
            if (article==null)
            {
                return BadRequest();
            }
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction("Articles");
        }

        [HttpGet]
        public IActionResult Cites(int id)
        {
            ViewData["id"] = id;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateCite(int SourceArticleID)
        {
            if (!await _context.Articles.AnyAsync(a=>a.ID==SourceArticleID))
            {
                return BadRequest();
            }
            CreateArticleArticleEditModel model = new CreateArticleArticleEditModel()
            {
                SourceArticleID = SourceArticleID
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCite(CreateArticleArticleEditModel model)
        {
            if (ModelState.IsValid)
            {
                ArticleArticle articleArticle = _mapper.Map<ArticleArticle>(model);
                await _context.ArticleArticles.AddAsync(articleArticle);
                await _context.SaveChangesAsync();
                return Redirect("/Article/Cites?id="+model.SourceArticleID);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult CitedBys(int id)
        {
            ViewData["id"] = id;
            return View();
        }
    }
}
