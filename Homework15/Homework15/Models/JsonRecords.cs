using Homework15.Abstractions;

namespace Homework15.Models
{
    public class JsonRecords
    {
        private readonly IFileOperations _records;
        public JsonRecords(IFileOperations records)
        {
            _records = records;
        }
    }
}
