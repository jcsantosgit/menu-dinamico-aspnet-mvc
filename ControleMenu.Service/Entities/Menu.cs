namespace ControleMenu.Service.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Acao { get; set; }
        public string Controlador { get; set; }
        public int? IdPai { get; set; }
    }
}
