namespace SirmaOOPExam.Infrastructure.UI.Menus.Interfaces
{
    internal interface IMenu
    {
        string Title { get; set; }
        int DisplayMenu();
        void RegisterOption(IMenuOption option);
    }
}