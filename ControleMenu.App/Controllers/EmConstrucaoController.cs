using ControleMenu.App.Models;
using ControleMenu.Service.Repository;
using System.Web.Mvc;

namespace ControleMenu.App.Controllers
{
    public class EmConstrucaoController : Controller
    {
        public EmConstrucaoController()
        {
            var _repository = new MenuRepository();
            ViewBag.Menus = MenuViewModel.ConstruirMenu(_repository.Listar());
        }
        // GET: EmConstrucao
        public ActionResult Index()
        {
            return View();
        }
    }
}