using Homework15.Models;
using System.Text.Json.Nodes;

namespace Homework15.Abstractions
{
    public interface IFileOperations
    {
        void saveJson(Patient patient);
        List<Patient> showJson();
    }
}
