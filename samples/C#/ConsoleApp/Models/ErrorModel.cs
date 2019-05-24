using System.Collections.Generic;

namespace ConsoleApp.Models
{
    class ErrorModel
    {
        public string Message { get; set; }
        public SeverityLevel Severity { get; set; }
        public int ErrorCode { get; set; }
        public IEnumerable<ErrorModel> Exceptions { get; set; }
        public int DocumentIndex { get; set; }

        public enum SeverityLevel { Error = 0, Warning = 1 }
    }
}