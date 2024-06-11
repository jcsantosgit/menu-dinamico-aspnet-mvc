using ControleMenu.App.Models;
using ControleMenu.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ControleMenu.App.Controllers
{
    public class GerenciarMenuController : Controller
    {
        MenuRepository _repository = null;

        public GerenciarMenuController()
        {
            _repository = new MenuRepository();
            ViewBag.Menus = MenuViewModel.ConstruirMenu(_repository.Listar());
        }

        // GET: GerenciarMenu
        public ActionResult Index()
        {
            List<MenuViewModel> models = MenuViewModel.ParseEntitiesToModels(_repository.Listar());
            return View(models);
        }

        public ActionResult Cadastrar()
        {
            var query = _repository
                .Listar()
                .ToList();

            ViewBag.Pais = query;

            return View(new MenuViewModel());
        }

        [HttpPost]
        public ActionResult Cadastrar(MenuViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = MenuViewModel.ParseModelToEntity(model);
                    _repository.Adicionar(entity);
                    TempData["mensagem"] = "Cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Remover(int id)
        {
            try
            {
                if(id == 1)
                {
                    TempData["mensagem"] = "Esse menu não pode ser removido!";
                    return RedirectToAction("Index");
                }

                _repository.Remover(id);
                TempData["mensagem"] = "Removido com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}