using System;
using System.Threading.Tasks;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.ViewModels.Faculty;

namespace UniversityProject.BusinessLogic.Services
{
    public class AdminService : IAdminService
    {
        #region Properties
        #endregion

        #region Constructors
        public AdminService()
        {
        }
        #endregion

        #region Public Methods
        public Task CreateFaculty(CreateFacultyAdminView viewModel)
        {
            throw new NotImplementedException();
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
