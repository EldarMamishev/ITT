namespace UniversityProject.BusinessLogic.Models.Paging
{
    public class PartialSearchModel : PagerModel
    {
        public string SearchQuery { get; set; }

        public string Title { get; set; }
    }
}
