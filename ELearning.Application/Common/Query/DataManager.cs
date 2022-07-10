namespace ELearning.Application.Common.Query
{
    public class DataManager
    {
        public DataManager(int? take = null, int? skip = null, string searchValue = null)
        {
            Take = take;
            Skip = skip;
            SearchValue = searchValue;
        }

        public int? Take { get; set; }
        public int? Skip { get; set; }
        public string SearchValue { get; set; }
    }
}
