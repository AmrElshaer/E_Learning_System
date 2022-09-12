using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace E_Learning_System.Helpers.Extensions
{
    public static class ModelStateExtensions
    {
        public static IDictionary<string, List<string>> AllErrors(this ModelStateDictionary modelState)
        {

            return GetErros(modelState).GroupBy(a => a.Key)
                .ToDictionary(a => a.Key,
                a => a.Select(e => e.Error).ToList());

        }

        private static IEnumerable<ErrorResult> GetErros(ModelStateDictionary modelState)
        {
            return modelState.Where(ms => ms.Value.Errors.Any())
                                              .Select(x => new ErrorResult(x.Key.Contains('.') ? x.Key.Split('.')[1] : "",
                                              x.Value.Errors.FirstOrDefault()?.ErrorMessage));

        }
    }
    class ErrorResult
    {
        public ErrorResult(string key, string error)
        {
            Key = key;
            Error = error;
        }

        public string Key { get; set; }
        public string Error { get; set; }
    }
}
