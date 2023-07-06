using AutoFixture;
using DBApiTutorial.Features.Employees;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Features.Employees.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DBApiTutorial.Test.Features.Employees
{
    public class EmployeesControllerTest
    {
        private EmployeesController _employeesController;
        private Mock<IMediator> _mediatorMock;
        private Fixture _fixture;

        public EmployeesControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _fixture = new Fixture();
            _employeesController = new EmployeesController(_mediatorMock.Object);
        }

        [Fact]
        public async void GetEmployees_ShouldReturnEmployees()
        {
            var expectedResult = _fixture.Create<ActionResult<IEnumerable<EmployeeDto>>>();

            _mediatorMock.Setup(x => x.Send(It.IsAny<GetEmployees.Query>(), default)).ReturnsAsync(expectedResult);

            var employeesResult = await _employeesController.GetEmployees();

            Assert.IsType<OkObjectResult>(employeesResult.Result);
        }

        [Fact]
        public async void GetEmployeeById_ShouldReturnEmployeeOfId()
        {
            var expectedResult = _fixture.Create<ActionResult<EmployeeDto?>>();
            int employeeId = expectedResult.Value.Id;

            _mediatorMock.Setup(x => x.Send(It.IsAny<GetEmployeeById.Query>(), default)).ReturnsAsync(expectedResult);

            var employeeResult = await _employeesController.GetEmployeeById(employeeId);

            Assert.IsType<OkObjectResult>(employeeResult.Result);
        }

        [Fact]
        public async void CreateEmployee_ShouldReturnCreatedEmployee()
        {
            var employeeToCreate = _fixture.Create<EmployeeCreateDto>();
            var expectedResult = _fixture.Create<ActionResult<EmployeeDto>>();

            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateEmployee.Command>(), default)).ReturnsAsync(expectedResult);

            var employeeResult = await _employeesController.CreateEmployee(employeeToCreate);

            Assert.IsType<CreatedResult>(employeeResult.Result);
        }

        [Fact]
        public async void UpdateEmployee_ShouldReturnUpdatedEmployee()
        {
            var employee = _fixture.Create<EmployeeDto>();
            var updatedEmployee = _fixture.Create<EmployeeUpdateDto>();
            var expectedResult = _fixture.Create<ActionResult<EmployeeDto>>();

            _mediatorMock.Setup(x => x.Send(It.IsAny<UpdateEmployee.Command>(), default)).ReturnsAsync(expectedResult);

            ActionResult<EmployeeDto> employeeResult = await _employeesController.UpdateEmployee(employee.Id, updatedEmployee);

            Assert.IsType<OkObjectResult>(employeeResult.Result);
        }

        [Fact]
        public async void DeleteEmployee_ShouldDeleteEmployee()
        {
            var expectedResult = _fixture.Create<ActionResult<EmployeeDto>>();

            _mediatorMock.Setup(x => x.Send(It.IsAny<DeleteEmployee.Command>(), default)).ReturnsAsync(expectedResult.Value.Id);

            var employeeResult = await _employeesController.DeleteEmployee(expectedResult.Value.Id);

            Assert.IsType<OkObjectResult>(employeeResult.Result);
        }

    }
}