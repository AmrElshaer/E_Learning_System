using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;

namespace E_Learning_System.Controllers
{

    public class TestController : ApiController
    {
        public async Task<string> Get()
        {
            var jsonTask = await GetJsonAsync().ConfigureAwait(false);
            return jsonTask.ToString();
        }
        private async Task<string> GetJsonAsync()
        {
            Debug.Write("Get Data");// Runs synchronously in the UI Thread ( ASP.NET request context.)
            await Task.Delay(1000);// Runs on worker thread (seperate thread)
            Debug.Write("Finish");// continuation task which in this case run in UI Thread
            return "Data..";
        }
    }
}
