using Homework15.Abstractions;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Globalization;
using System.Text.Json.Nodes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Homework15.Models
{
    public class JsonFile : IFileOperations
    {

        private string filePath = @"C:\Users\user\Desktop\Homeworks\Homework15\Homework15\Homework15\Files\Reservations.json";
       
        public void saveJson(Patient patient)
        {
            string content = File.ReadAllText(filePath);

            List<Patient> recordList = string.IsNullOrEmpty(content)
            ? new List<Patient>()
            : JsonConvert.DeserializeObject<List<Patient>>(content) ?? new List<Patient>();

            var record = new Patient()
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DoctorType = patient.DoctorType,
                VisitTime = patient.VisitTime,

            };

            recordList?.Add(record);


            var updatedJson = JsonConvert.SerializeObject(recordList, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);

         }

        public List<Patient> showJson()
        {
            var content = File.ReadAllText(filePath);
            var updatedJson = JsonConvert.DeserializeObject<List<Patient>>(content);
            return updatedJson;
        }
    }
}
