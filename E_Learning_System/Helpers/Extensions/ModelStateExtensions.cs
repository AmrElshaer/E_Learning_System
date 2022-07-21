using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace E_Learning_System.Helpers.Extensions
{
    public static class ModelStateExtensions
    {
        public static IDictionary<string, List<string>> AllErrors(this ModelStateDictionary modelState)
        {
            var result = new Dictionary<string, List<string>>();
            var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any())
                                            .Select(x => new { x.Key, x.Value.Errors });

            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key.Split('.')[1];
                var fieldErrors = erroneousField.Errors.FirstOrDefault()?.ErrorMessage;
                if (result.ContainsKey(fieldKey))
                {
                    result[fieldKey].Add(fieldErrors);
                }
                else
                {
                    var validation = new List<string>();
                    validation.Add(fieldErrors);
                    result.Add(fieldKey, validation);
                }
            }

            return result;
        }
    }
}
