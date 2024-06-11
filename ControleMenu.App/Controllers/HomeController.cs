using ControleMenu.App.Models;
using ControleMenu.Service.Repository;
using System.Web.Mvc;

namespace ControleMenu.App.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            var _repository = new MenuRepository();
            ViewBag.Menus = MenuViewModel.ConstruirMenu(_repository.Listar());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}