using System.Threading.Tasks;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.DataAccess.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.Faculty;

namespace UniversityProject.BusinessLogic.Services
{
    public class AdminService : IAdminService
    {
        #region Properties
        private IFacultyRepository _facultyRepository;

        private IFacultyMapper _facultyMapper;
        #endregion

        #region Constructors
        public AdminService(IFacultyRepository facultyRepository, IFacultyMapper facultyMapper)
        {
            _facultyRepository = facultyRepository;
            _facultyMapper = facultyMapper;
        }
        #endregion

        #region Public Methods
        public async Task CreateFaculty(CreateFacultyAdminView viewModel)
        {
            Faculty faculty = _facultyMapper.MapToFacultyModel(viewModel);
            await _facultyRepository.Create(faculty);
        }

        //private async Task<UsersSummaryResponse> GetSummaryAsync(string accessToken, int locationDetailId, int pageSize, int pageNumber = 1, string searchQuery = null)
        //{
        //    UsersSummaryRequest request = new UsersSummaryRequest
        //    {
        //        VersionNumber = VERSION_NUMBER,
        //        Token = _requestToken,
        //        LocationDetailId = locationDetailId,
        //        PageSize = pageSize,
        //        PageNumber = pageNumber,
        //        QuickSearch = searchQuery
        //    };
        //    string requestResult = await ExecutePostAsync(GET_SUMMARY_URL, request, accessToken);
        //    UsersSummaryResponse result = JsonConvert.DeserializeObject<UsersSummaryResponse>(requestResult);
        //    PayloadListNullCheck(result.PayLoad);
        //    return result;
        //}
        #endregion
    }
}