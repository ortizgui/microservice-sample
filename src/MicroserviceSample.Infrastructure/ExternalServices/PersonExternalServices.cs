using System.Threading.Tasks;
using MicroserviceSample.Domain.Dtos;
using MicroserviceSample.Domain.Entities;
using MicroserviceSample.Domain.ExternalServices;

namespace MicroserviceSample.Infrastructure.ExternalServices
{
    public class PersonExternalServices : IPersonExternalServices
    {
        public Task<Person> GetPersonByName(string name)
        {
            var person = new Person()
                {
                    Name = name,
                    DocId = "12345678901"
                };

            return Task.FromResult(person);
        }
    }
}