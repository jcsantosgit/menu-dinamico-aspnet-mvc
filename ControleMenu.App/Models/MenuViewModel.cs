using ControleMenu.Service.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ControleMenu.App.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo nome obrigatório")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Campo nome obrigatório")]
        public string Acao { get; set; }

        [Required(ErrorMessage = "Campo nome obrigatório")]
        public string Controlador { get; set; }
        public int? IdPai { get; set; }
        public List<MenuViewModel> Submenu { get; set; }

        public static Menu ParseModelToEntity(MenuViewModel model)
        {
            try
            {
                Menu entity = new Menu();
                entity.Id = model.Id;
                entity.Nome = model.Nome;
                entity.Acao = model.Acao;
                entity.Controlador = model.Controlador;
                entity.IdPai = model.IdPai;

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static MenuViewModel ParseEntityToModel(Menu entity)
        {
            try
            {
                MenuViewModel vm = new MenuViewModel();
                vm.Id = entity.Id;
                vm.Nome = entity.Nome;
                vm.Acao = entity.Acao;
                vm.Controlador = entity.Controlador;
                vm.IdPai = entity.IdPai;
                vm.Submenu = new List<MenuViewModel>();

                return vm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<MenuViewModel> ParseEntitiesToModels(List<Menu> entities) 
        {
            try
            {
                List<MenuViewModel> models = new List<MenuViewModel>();
                foreach (var entity in entities)
                {
                    models.Add(ParseEntityToModel(entity));
                }
                return models;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<MenuViewModel> ConstruirMenu(List<Menu> entities)
        {
            try
            {
                var raiz = entities
                    .Where(e => e.IdPai == null)
                    .ToList();

                List<MenuViewModel> menus = ParseEntitiesToModels(raiz);

                foreach (var menu in menus)
                {
                    EstruturarMenu(menu, entities);
                }

                return menus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void EstruturarMenu(MenuViewModel menu, List<Menu> entities)
        {
            var query = entities
                .Where(e => e.IdPai.HasValue && e.IdPai == menu.Id)
                .ToList();

            if(query != null && query.Count > 0)
            {
                foreach (var q in query)
                {
                    MenuViewModel submenu = new MenuViewModel();
                    submenu.Id = q.Id;
                    submenu.Nome = q.Nome;
                    submenu.IdPai = q.IdPai;
                    submenu.Acao = q.Acao;
                    submenu.Controlador = q.Controlador;
                    submenu.Submenu = new List<MenuViewModel>();
                    menu.Submenu.Add(submenu);
                    EstruturarMenu(submenu, entities);
                }
            }
        }
    }
}