using System;
using System.Threading;
using System.Threading.Tasks;
using MicroserviceSample.Domain.Commands;
using MicroserviceSample.Domain.Entities;
using MicroserviceSample.Domain.ExternalServices;
using MicroserviceSample.Domain.Handler;
using Moq;
using Xunit;

namespace MicroserviceSample.Test.unit.Domain.Handler
{
    public class GetPersonHandlerTests
    {
        private Mock<IPersonExternalServices> _mockExternalServices;

        [Fact]
        public async void Should_Pass_Return_Is_Valid()
        {
            _mockExternalServices = new Mock<IPersonExternalServices>();

            _mockExternalServices.Setup(e => 
                e.GetPersonByName(It.IsAny<string>()))
                .Returns(Task.FromResult(new Person()));

            var handler = new GetPersonHandler(_mockExternalServices.Object);

            var response = await handler.Handle(new GetPersonCommand(), CancellationToken.None);
            
            _mockExternalServices.VerifyAll();
        }
        
        [Fact]
        public async void Should_Return_Please_try_again_later()
        {
            _mockExternalServices = new Mock<IPersonExternalServices>();

            _mockExternalServices.Setup(e => 
                e.GetPersonByName(It.IsAny<string>()))
                .Throws(new Exception());

            var handler = new GetPersonHandler(_mockExternalServices.Object);

            var response = await handler.Handle(new GetPersonCommand(), CancellationToken.None);
            
            Assert.Equal("Please try again later.", response.Message);
        }
    }
}