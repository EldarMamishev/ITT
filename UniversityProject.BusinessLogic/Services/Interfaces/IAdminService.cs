using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversityProject.ViewModels.AdminViewModels.ChairViewModels;
using UniversityProject.ViewModels.AdminViewModels.GroupViewModels;
using UniversityProject.ViewModels.AdminViewModels.SubjectsViewModels;
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
        Task CreateChair(CreateChairAdminView viewModel);
        Task<EditChairDataAdminView> EditChair(int id);
        Task EditChair(EditChairAdminView viewModel);
        Task DeleteChair(int id);
        #endregion

        #region Groups
        Task<ShowGroupsAdminView> ShowGroups();
        Task<CreateGroupDataAdminView> LoadDataForCreateGroupPage();
        Task<JsonResult> LoadChairsByFacultyId(int facultyId);
        Task CreateGroup(CreateGroupAdminView viewModel);
        Task<EditGroupDataAdminView> EditGroup(int id);
        Task EditGroup(EditGroupAdminView viewModel);
        Task DeleteGroup(int id);
        #endregion

        #region Subjects
        Task<ShowSubjectsAdminView> ShowSubjects();
        Task<ResponseSubjectView> CreateSubject(string subjectName);
        Task<ResponseSubjectView> EditSubject(RequestSubjectView requestViewModel);
        Task DeleteSubject(int id);
        #endregion
    }
}