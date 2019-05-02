using System.Threading.Tasks;
using UniversityProject.ViewModels.Faculty;

namespace UniversityProject.BusinessLogic.Services.Interfaces
{
    public interface IAdminService
    {
        Task<ShowFacultiesAdminView> ShowFaculties();
        Task CreateFaculty(CreateFacultyAdminView viewModel);
        Task<EditFacultyAdminView> EditFaculty(int id);
        Task EditFaculty(EditFacultyAdminView viewModel);
    }
}