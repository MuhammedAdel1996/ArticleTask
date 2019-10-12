using ArticleTask.IRepository;
using ArticleTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ArticleTask.Controllers
{
    public class ArticleController : Controller
    {
        //ApplicationDbContext DB = new ApplicationDbContext();
        // GET: Article
        readonly IRepository<Article> IRepositoryArticle;
        readonly IRepository<ArticleCategory> IRepositoryArticleCategory;
        readonly IRepository<Comments> IRepositoryComments;

        public ArticleController(IRepository<Article> IRepositoryArticle, IRepository<ArticleCategory> IRepositoryArticleCategory, IRepository<Comments> IRepositoryComments)
        {
            this.IRepositoryArticle = IRepositoryArticle;
            this.IRepositoryArticleCategory = IRepositoryArticleCategory;
            this.IRepositoryComments = IRepositoryComments;
        }


        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult AddArticle()
        {
            Categorieslist();

            return View();
        }
        [HttpPost]
        public ActionResult AddArticle(Article article)
        {
            this.IRepositoryArticle.AddEntity(article);
            this.IRepositoryArticle.complete();

            return RedirectToAction(nameof(Articles), new RouteValueDictionary(
 new { controller = "Article", action = nameof(Articles) }));
        }
        public ActionResult Articles(int? categoryid)
        {
            Categorieslist();
            if (categoryid!=null)
            {
                var csutomeresult = this.IRepositoryArticle.GetAllEntities().Where(s => s.categoryid == categoryid).ToList();
                return View(csutomeresult);

            }
          
                var allreuslt = this.IRepositoryArticle.GetAllEntities().ToList();
                return View(allreuslt);
            
       
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Addcategroy()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Addcategroy(ArticleCategory articleCategory)
        {
            this.IRepositoryArticleCategory.AddEntity(articleCategory);
            this.IRepositoryArticleCategory.complete();
            return RedirectToAction(nameof(AddArticle), new RouteValueDictionary(
new { controller = "Article", action = nameof(AddArticle) }));

        }
        [HttpGet]
        public ActionResult Addcomment(int id)
        {
            ViewBag.articleid = id;
            return View();
        }
        [HttpPost]
        public ActionResult Addcomment(Comments comments)
        {
            this.IRepositoryComments.AddEntity(comments);
            this.IRepositoryComments.complete();
            return RedirectToAction(nameof(Articles), new RouteValueDictionary(
new { controller = "Article", action = nameof(Articles) }));

        }
        public ActionResult comments(int id)
        {
            var csutomeresult = this.IRepositoryComments.GetAllEntities().Where(s => s.articaleid == id).ToList();
            return View(csutomeresult);
        }
        public void Categorieslist()
        {
            var categories = this.IRepositoryArticleCategory.GetAllEntities().ToList();
            IList<SelectListItem> list = categories.Select(x=> new SelectListItem { Text=x.name,Value=x.id.ToString()}).ToList();
            SelectList data = new SelectList(list, "Value", "Text");
            ViewBag.categories = data;
        }

    }
}