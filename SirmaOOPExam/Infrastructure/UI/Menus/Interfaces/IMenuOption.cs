namespace SirmaOOPExam.Infrastructure.UI.Menus.Interfaces
{
    public interface IMenuOption
    {
        public string MenuText { get; }
        public int CommandNumber { get; }
        void Execute();
    }
}
