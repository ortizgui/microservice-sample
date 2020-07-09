using System.Threading.Tasks;
using MicroserviceSample.Domain.Dtos;
using MicroserviceSample.Domain.Entities;

namespace MicroserviceSample.Domain.ExternalServices
{
    public interface IPersonExternalServices
    {
        Task<Person> GetPersonByName(string name);
    }
}