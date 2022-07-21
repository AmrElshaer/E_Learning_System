namespace ELearning.Application.Common.Exceptions
{
    public class ValidationResult
    {
        public ValidationResult(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; set; }
        public string Message { get; set; }
    }
}
