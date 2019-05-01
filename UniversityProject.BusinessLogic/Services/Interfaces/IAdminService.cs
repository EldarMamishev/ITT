using System.Threading.Tasks;
using UniversityProject.ViewModels.Faculty;

namespace UniversityProject.BusinessLogic.Services.Interfaces
{
    public interface IAdminService
    {
        Task CreateFaculty(CreateFacultyAdminView viewModel);
    }
}