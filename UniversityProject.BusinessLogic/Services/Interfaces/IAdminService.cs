using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversityProject.ViewModels.AdminViewModels.CathedraViewModels;
using UniversityProject.ViewModels.AdminViewModels.GroupViewModels;
using UniversityProject.ViewModels.AdminViewModels.StudentViewModels;
using UniversityProject.ViewModels.AdminViewModels.SubjectsViewModels;
using UniversityProject.ViewModels.AdminViewModels.TeacherViewModels;
using UniversityProject.ViewModels.Faculty;

namespace UniversityProject.BusinessLogic.Services.Interfaces
{
    public interface IAdminService
    {
        #region Cathedras
        Task<ShowCathedrasAdminView> ShowCathedras();
        Task<CreateCathedraDataAdminView> LoadDataForCreateCathedraPage();
        Task CreateCathedra(CreateCathedraAdminView viewModel);
        Task<EditCathedraDataAdminView> EditCathedra(int id);
        Task EditCathedra(EditCathedraAdminView viewModel);
        Task DeleteCathedra(int id);
        #endregion
        
        #region Subjects
        Task<ShowSubjectsAdminView> ShowSubjects();
        Task<ResponseSubjectView> CreateSubject(string subjectName);
        Task<ResponseSubjectView> EditSubject(RequestSubjectView requestViewModel);
        Task DeleteSubject(int id);
        #endregion

        #region Teachers
        Task<ShowTeachersAdminView> ShowTeachers();
        Task RegisterTeacher(RegisterNewTeacherUserAccountView viewModel);
        Task<EditTeacherDataAccountView> LoadDataForEditTeacherAccount(string userName);
        Task EditTeacherInformation(EditTeacherInformationView viewModel);
        Task<RegisterNewTeacherUserDataAccountView> LoadDataForRegisterTeacherPage();
        #endregion

        #region Students
        Task<ShowStudentsAdminView> ShowStudents();
        Task RegisterStudent(RegisterNewStudentUserAccountView viewModel);
        Task<EditStudentDataAccountView> LoadDataForEditStudentAccount(string userName);
        Task EditStudentInformation(EditStudentInformationView viewModel);
        Task<RegisterNewStudentUserDataAccountView> LoadDataForRegisterStudentPage();
        #endregion
    }
}