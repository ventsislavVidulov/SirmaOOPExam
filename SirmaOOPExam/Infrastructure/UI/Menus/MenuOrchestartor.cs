using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;

namespace SirmaOOPExam.Infrastructure.UI.Menus
{
    //not used
    internal class MenuOrchestartor
    {
        private List<IMenu> _menus = new();

        public void RegisterMenu(IMenu menu)
        {
            _menus.Add(menu);
        }

        public void DisplayMenu(string menuName)
        {
            _menus.FirstOrDefault(m => m.Title == menuName).DisplayMenu();
        }
    }
}
