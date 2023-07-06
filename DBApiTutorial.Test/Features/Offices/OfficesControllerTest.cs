using AutoFixture;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Offices;
using DBApiTutorial.Features.Offices.DTO;
using DBApiTutorial.Features.Offices.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Swashbuckle.SwaggerUi;
using System.Collections.Generic;

namespace DBApiTutorial.Test.Features.Offices
{
    public class OfficesControllerTest
    {
        private OfficesController _OfficesController;
        private Mock<IMediator> _mediatorMock;
        private Fixture _fixture;

        public OfficesControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _fixture = new Fixture();
            _OfficesController = new OfficesController(_mediatorMock.Object);
        }

        [Fact]
        public async void GetOffices_ShouldReturnOffices()
        {
            var expectedResult = _fixture.Create<ActionResult<IEnumerable<OfficeDto>>>();

            _mediatorMock.Setup(x => x.Send(It.IsAny<GetOffices.Query>(), default)).ReturnsAsync(expectedResult);

            var officesResult = await _OfficesController.GetOffices();

            Assert.IsType<OkObjectResult>(officesResult.Result);
        }

        [Fact]
        public async void GetOfficeById_ShouldReturnOfficeOfId()
        {
            var expectedResult = _fixture.Create<ActionResult<OfficeDto?>>();
            int officeId = expectedResult.Value.Id;

            _mediatorMock.Setup(x => x.Send(It.IsAny<GetOfficeById.Query>(), default)).ReturnsAsync(expectedResult);

            var officeResult = await _OfficesController.GetOffice(officeId);

            Assert.IsType<OkObjectResult>(officeResult.Result);
        }

        [Fact]
        public async void CreateOffice_ShouldReturnCreatedOffice()
        {
            var officeToCreate = _fixture.Create<OfficeCreateDto>();
            var expectedResult = _fixture.Create<ActionResult<OfficeDto>>();

            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateOffice.Command>(), default)).ReturnsAsync(expectedResult);

            var officeResult = await _OfficesController.CreateOffice(officeToCreate);

            Assert.IsType<CreatedResult>(officeResult.Result);
        }

        [Fact]
        public async void UpdateOffice_ShouldReturnUpdatedOffice()
        {
            var office = _fixture.Create<OfficeDto>();
            var updatedOffice = _fixture.Create<OfficeUpdateDto>();
            var expectedResult = _fixture.Create<ActionResult<OfficeDto>>();

            _mediatorMock.Setup(x => x.Send(It.IsAny<UpdateOffice.Command>(), default)).ReturnsAsync(expectedResult);

            ActionResult<OfficeDto> OfficeResult = await _OfficesController.UpdateOffice(office.Id, updatedOffice);

            Assert.IsType<OkObjectResult>(OfficeResult.Result);
        }

        [Fact]
        public async void DeleteOffice_ShouldDeleteOffice()
        {
            var expectedResult = _fixture.Create<ActionResult<OfficeDto>>();

            _mediatorMock.Setup(x => x.Send(It.IsAny<DeleteOffice.Command>(), default)).ReturnsAsync(expectedResult.Value.Id);

            var officeResult = await _OfficesController.DeleteOffice(expectedResult.Value.Id);

            Assert.IsType<OkObjectResult>(officeResult.Result);
        }

    }
}