using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using UniversityProject.BusinessLogic.Fabrics.Interfaces;
using UniversityProject.Shared.Constants;
using UniversityProject.ViewModels.MenuViewModels;

namespace UniversityProject.BusinessLogic.Fabrics
{
    public class MenuItemsFabric : IMenuItemsFabric
    {
        #region Properties & variables
        private IHttpContextAccessor _httpContextAccessor;
        protected List<string> UserRoles => _httpContextAccessor.HttpContext.User.Claims
            .Where(item => item.Type == ClaimTypes.Role)?
            .Select(item => item.Value).ToList();
        #endregion

        #region Constructors
        public MenuItemsFabric(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Public Methods
        public MenuViewModel BuildMenu()
        {
            var result = new MenuViewModel();

            foreach (string userRole in UserRoles)
            {
                if (userRole == ApplicationConstants.ADMIN_ROLE)
                {
                    AddAdminMenuViewModelItems(result.Items);
                }
                if (userRole == ApplicationConstants.TEACHER_ROLE)
                {
                    AddTeacherMenuViewModelItems(result.Items);
                }
                if (userRole == ApplicationConstants.USER_ROLE)
                {
                    AddUserMenuViewModelItems(result.Items);
                }
            }

            return result;
        }
        #endregion

        #region Private Methods
        private void TryAddMenuViewModelItem(List<MenuViewModelItem> items, MenuViewModelItem itemToAdd)
        {
            if (items.Any(item => item.Title == itemToAdd.Title 
            || (item.ControllerName == itemToAdd.ControllerName 
            && item.ActionName == itemToAdd.ActionName)))
            {
                return;
            }

            items.Add(itemToAdd);
        }

        private void AddAdminMenuViewModelItems(List<MenuViewModelItem> items)
        {
            MenuViewModelItem item = null;

            item = new MenuViewModelItem()
            {
                Title = "Головна",
                ControllerName = "Admin",
                ActionName = "Index"
            };
            TryAddMenuViewModelItem(items, item);

            item = new MenuViewModelItem()
            {
                Title = "Факультети",
                ControllerName = "Admin",
                ActionName = "ShowFaculties"
            };
            TryAddMenuViewModelItem(items, item);

            item = new MenuViewModelItem()
            {
                Title = "Кафедри",
                ControllerName = "Admin",
                ActionName = "ShowChairs"
            };
            TryAddMenuViewModelItem(items, item);

            item = new MenuViewModelItem()
            {
                Title = "Групи",
                ControllerName = "Admin",
                ActionName = "ShowGroups"
            };
            TryAddMenuViewModelItem(items, item);

            item = new MenuViewModelItem()
            {
                Title = "Викладачі",
                ControllerName = "Teacher",
                ActionName = "Index"
            };
            TryAddMenuViewModelItem(items, item);

            item = new MenuViewModelItem()
            {
                Title = "Студенти",
                ControllerName = "Student",
                ActionName = "Index"
            };
            TryAddMenuViewModelItem(items, item);

            item = new MenuViewModelItem()
            {
                Title = "Журнали",
                ControllerName = "Admin",
                ActionName = "ShowJournals"
            };
            TryAddMenuViewModelItem(items, item);

            item = new MenuViewModelItem()
            {
                Title = "Календар занять",
                ControllerName = "Admin",
                ActionName = "ShowScheduler"
            };
            TryAddMenuViewModelItem(items, item);
        }

        private void AddTeacherMenuViewModelItems(List<MenuViewModelItem> items)
        {
            MenuViewModelItem item = null;

            item = new MenuViewModelItem()
            {
                Title = "Home",
                ControllerName = "KnowledgeBase",
                ActionName = "Index"
            };
            TryAddMenuViewModelItem(items, item);
            
            item = new MenuViewModelItem()
            {
                Title = "New Item Form",
                ControllerName = "ItemForm",
                ActionName = "Create"
            };
            TryAddMenuViewModelItem(items, item);
        }

        private void AddUserMenuViewModelItems(List<MenuViewModelItem> items)
        {
            MenuViewModelItem item = null;

            item = new MenuViewModelItem()
            {
                Title = "Home",
                ControllerName = "KnowledgeBase",
                ActionName = "Index"
            };
            TryAddMenuViewModelItem(items, item);

            item = new MenuViewModelItem()
            {
                Title = "Journal",
                ControllerName = "Journal",
                ActionName = "Index"
            };
            TryAddMenuViewModelItem(items, item);

            item = new MenuViewModelItem()
            {
                Title = "Cabinet",
                ControllerName = "Account",
                ActionName = ""/////////???????????????
            };
            TryAddMenuViewModelItem(items, item);
        }
        #endregion
    }
}