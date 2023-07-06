using AutoFixture;
using DBApiTutorial.Features.Regions;
using DBApiTutorial.Features.Regions.DTO;
using DBApiTutorial.Features.Regions.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DBApiTutorial.Test.Features.Regions
{
    public class RegionsControllerTest
    {
        private RegionsController _regionsController;
        private Mock<IMediator> _mediatorMock;
        private Fixture _fixture;

        public RegionsControllerTest() 
        {
            _mediatorMock = new Mock<IMediator>();
            _fixture = new Fixture();
            _regionsController = new RegionsController(_mediatorMock.Object);
        }

        [Fact]
        public async void GetRegions_ShouldReturnRegions()
        {
            var expectedResult = _fixture.Create<ActionResult<IEnumerable<RegionDto>>>();

            _mediatorMock.Setup(x => x.Send(It.IsAny<GetRegions.Query>(), default)).ReturnsAsync(expectedResult);

            var regionsResult = await _regionsController.GetRegions();

            Assert.IsType<OkObjectResult>(regionsResult.Result);
        }

        [Fact]
        public async void GetRegionById_ShouldReturnRegionOfId()
        {
            var expectedResult = _fixture.Create<ActionResult<RegionDto?>>();
            int regionId = expectedResult.Value.Id;

            _mediatorMock.Setup(x => x.Send(It.IsAny<GetRegionById.Query>(), default)).ReturnsAsync(expectedResult);

            var regionResult = await _regionsController.GetRegion(regionId);

            Assert.IsType<OkObjectResult>(regionResult.Result);
        }

        [Fact]
        public async void CreateRegion_ShouldReturnCreatedRegion()
        {
            var regionToCreate = _fixture.Create<RegionCreateDto>();
            var expectedResult = _fixture.Create<ActionResult<RegionDto>>();

            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateRegion.Command>(), default)).ReturnsAsync(expectedResult);
            
            var regionResult = await _regionsController.CreateRegion(regionToCreate);

            Assert.IsType<CreatedResult>(regionResult.Result);
        }

        [Fact]
        public async void UpdateRegion_ShouldReturnUpdatedRegion()
        {
            var region = _fixture.Create<RegionDto>();
            var updatedRegion = _fixture.Create<RegionUpdateDto>();
            var expectedResult = _fixture.Create<ActionResult<RegionDto>>();

            _mediatorMock.Setup(x => x.Send(It.IsAny<UpdateRegion.Command>(), default)).ReturnsAsync(expectedResult);

            ActionResult<RegionDto> regionResult = await _regionsController.UpdateRegion(region.Id, updatedRegion);

            Assert.IsType<OkObjectResult>(regionResult.Result);
        }

        [Fact]
        public async void DeleteRegion_ShouldDeleteRegion()
        {
            var expectedResult = _fixture.Create<ActionResult<RegionDto>>();

            _mediatorMock.Setup(x => x.Send(It.IsAny<DeleteRegion.Command>(), default)).ReturnsAsync(expectedResult.Value.Id);
            
            var regionResult = await _regionsController.DeleteRegion(expectedResult.Value.Id);

            Assert.IsType<OkObjectResult>(regionResult.Result);
        }

    }
}