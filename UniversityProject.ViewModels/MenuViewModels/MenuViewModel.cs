using System.Collections.Generic;

namespace UniversityProject.ViewModels.MenuViewModels
{
    public class MenuViewModel
    {
        public List<MenuViewModelItem> Items { get; set; }

        public MenuViewModel()
        {
            Items = new List<MenuViewModelItem>();
        }
    }

    public class MenuViewModelItem
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Title { get; set; }
    }
}