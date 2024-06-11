using ControleMenu.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleMenu.Service.Repository
{
    public class MenuRepository
    {
            
        static List<Menu> entities = null;

        public MenuRepository()
        {
            if (entities == null || entities.Count == 0)
                CarregarMenu();
        }

        private void CarregarMenu()
        {
            try
            {
                entities = new List<Menu>();

                entities.Add(new Menu { Id = 1, Nome = "Menu", Acao = "Index", Controlador = "GerenciarMenu", IdPai = null });
                entities.Add(new Menu { Id = 2, Nome = "Home", Acao = "Index", Controlador = "Home", IdPai = null });
                entities.Add(new Menu { Id = 3, Nome = "Produto", Acao = "Index", Controlador = "EmConstrucao", IdPai = null });
                entities.Add(new Menu { Id = 4, Nome = "Lista", Acao = "Index", Controlador = "EmConstrucao", IdPai = 3 });
                entities.Add(new Menu { Id = 5, Nome = "Cadastro", Acao = "Index", Controlador = "EmConstrucao", IdPai = 3 });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Menu> Listar()
        {
            try
            {
                return entities
                    .OrderBy(e=>e.Id)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Adicionar(Menu entity)
        {
            try
            {
                var query = entities.LastOrDefault();
                int id = query.Id + 1;
                entity.Id = id;
                entities.Add(entity);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Menu Buscar(int id)
        {
            try
            {
                var query = entities.Where(e => e.Id == id).FirstOrDefault();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alterar(Menu entity)
        {
            try
            {
                entities.Remove(entity);
                entities.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remover(int id)
        {
            List<Menu> tmp = new List<Menu>();
            tmp.AddRange(entities);

            try
            {
                var query = entities
                    .Where(e => e.Id == id)
                    .FirstOrDefault();

                if (query == null) throw new Exception("Item não encontrado");

                var tmpEntities = entities
                    .Where(e => e.Id != id)
                    .ToList();

                entities = RemoveFilho(query, tmpEntities);
            }
            catch (Exception ex)
            {
                entities = tmp;
                throw ex;
            }
        }

        private List<Menu> RemoveFilho(Menu item, List<Menu> lista)
        {
            try
            {
                lista = lista.Where(l => l.Id != item.Id).ToList();

                var filhos = lista
                    .Where(l => l.IdPai == item.Id)
                    .ToList();

                foreach (var f in filhos)
                {
                        lista = RemoveFilho(f, lista);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
