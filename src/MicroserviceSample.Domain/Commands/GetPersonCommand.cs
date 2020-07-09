using MediatR;
using MicroserviceSample.Domain.Dtos;
using MicroserviceSample.Domain.Entities;

namespace MicroserviceSample.Domain.Commands
{
    public class GetPersonCommand : IRequest<ServiceResponse<GetPersonDto>>
    {
        public string Name { get; set; }
    }
}