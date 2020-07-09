using System;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using MicroserviceSample.Domain.Commands;
using MicroserviceSample.Domain.Dtos;
using MicroserviceSample.Domain.Entities;
using MicroserviceSample.Domain.ExternalServices;

namespace MicroserviceSample.Domain.Handler
{
    public class GetPersonHandler : IRequestHandler<GetPersonCommand, ServiceResponse<GetPersonDto>>
    {
        private readonly IPersonExternalServices _externalServices;

        public GetPersonHandler(IPersonExternalServices personExternalServices)
        {
            _externalServices = personExternalServices;
        }

        public async Task<ServiceResponse<GetPersonDto>> Handle(GetPersonCommand request,
            CancellationToken cancellationToken)
        {
            var serviceResponse = new ServiceResponse<GetPersonDto>();

            try
            {
                var person = await _externalServices.GetPersonByName(request.Name);
                serviceResponse.Data = person.Adapt<GetPersonDto>();
                serviceResponse.Message = "Here is the info you asked about.";
            }
            catch
            {
                serviceResponse.Message = "Please try again later.";
            }

            return serviceResponse;
        }
    }
}