using Syncfusion.EJ2.Base;

namespace ELearning.Application.Common.Query
{
    public class BaseRequestQuery
    {
        public DataManagerRequest DM { get; set; }

        public BaseRequestQuery(DataManagerRequest dataManager)
        {
            DM = dataManager ?? new DataManagerRequest();
        }
    }
}
