using System.Threading.Tasks;
using UniversityProject.ViewModels.AdminViewModels.ChairViewModels;
using UniversityProject.ViewModels.Faculty;

namespace UniversityProject.BusinessLogic.Services.Interfaces
{
    public interface IAdminService
    {
        #region Faculties
        Task<ShowFacultiesAdminView> ShowFaculties();
        Task CreateFaculty(CreateFacultyAdminView viewModel);
        Task<EditFacultyAdminView> EditFaculty(int id);
        Task EditFaculty(EditFacultyAdminView viewModel);
        Task DeleteFaculty(int id);
        #endregion

        #region Chairs
        Task<ShowChairsAdminView> ShowChairs();
        Task<CreateChairDataAdminView> LoadDataForCreateChairPage();
        #endregion
    }
}