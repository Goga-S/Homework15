using Homework15.Abstractions;

namespace Homework15.Models
{
    public class Patient
    {
        private DateTime visitTime;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string DoctorType { get; set; }

        public DateTime VisitTime
        {
            get
            {
                return visitTime;
            }
            set
            {
                if (value.Hour < 10 || value.Hour > 19)
                {
                    throw new ArgumentOutOfRangeException("Visit time must be working hours!");
                }
                else
                {
                    visitTime = value;
                }

            }
        }

        private readonly IFileOperations _fileOperations;

        public Patient()
        {
            
        }

        public Patient(IFileOperations fileOperations)
        {
            _fileOperations = fileOperations;
        }


    }
}
