using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Sprout.Exam.Business.Services.Interfaces;
using Sprout.Exam.Common.DTOs;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.WebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.WebApp.UnitTests
{
    public class EmployeeControllerTests
    {
        //Test target
        private EmployeesController _target;

        //Dependencies
        private Mock<IEmployeeService> _employeeService;
        private List<EmployeeDto> _getEmployeeResponse;
        private EmployeeDto _getEmployeeByIdResponse;
        [SetUp]
        public void Setup()
        {
            _getEmployeeResponse = CreateEmployeesDto();
            _getEmployeeByIdResponse = CreateEmployeeDto();
            _employeeService = new Mock<IEmployeeService>();
            _employeeService.Setup(x => x.GetAll()).Returns(_getEmployeeResponse);
            _employeeService.Setup(x => x.GetById(It.IsAny<int>())).Returns(_getEmployeeByIdResponse);
            _target = new EmployeesController(_employeeService.Object);
        }

        /// <summary>
        ///     Workflow:       Get All Employees
        ///     Scenario:       Succeeds
        ///     Expected:       Returns Response, No Errors
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllEmployees_Succeeds_ReturnsAllEmployee()
        {
            //Arrange

            //Act
            var actionResult = await _target.Get();

            //Assert
            Assert.IsInstanceOf(typeof(ActionResult), actionResult);
            var objResult = actionResult as ObjectResult;
            var response = objResult.Value as IEnumerable<EmployeeDto>;
            Assert.AreEqual(200, objResult.StatusCode);
            Assert.AreEqual(_getEmployeeResponse.Count, response.Count());
            Assert.AreEqual(_getEmployeeResponse.First().Birthdate, response.First().Birthdate);
            Assert.AreEqual(_getEmployeeResponse.First().FullName, response.First().FullName);
            Assert.AreEqual(_getEmployeeResponse.First().Id, response.First().Id);
            Assert.AreEqual(_getEmployeeResponse.First().Tin, response.First().Tin);
            Assert.AreEqual(_getEmployeeResponse.First().TypeId, response.First().TypeId);

            _employeeService.Verify(i => i.GetAll(), Times.Once);
        }

        /// <summary>
        ///     Workflow:       Get All Employees
        ///     Scenario:       No Employee Found
        ///     Expected:       Returns 404 NotFound
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllEmployees_NoEmployeeFound_Returns404NotFound()
        {
            //Arrange
            _employeeService.Setup(x => x.GetAll()).Returns(new List<EmployeeDto>());

            //Act
            var actionResult = await _target.Get();

            //Assert
            Assert.IsInstanceOf(typeof(ActionResult), actionResult);
            var objResult = actionResult as StatusCodeResult;
            Assert.AreEqual(404, objResult.StatusCode);

            _employeeService.Verify(i => i.GetAll(), Times.Once);
        }

        /// <summary>
        ///     Workflow:       Get Employee By Id
        ///     Scenario:       Succeeds
        ///     Expected:       Returns Response, No Errors
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetEmployeeById_Succeeds_ReturnsEmployee()
        {
            //Arrange
            int employeeId = 1;
            //Act
            var actionResult = await _target.GetById(employeeId);

            //Assert
            Assert.IsInstanceOf(typeof(ActionResult), actionResult);
            var objResult = actionResult as ObjectResult;
            var response = objResult.Value as EmployeeDto;
            Assert.AreEqual(200, objResult.StatusCode);
            Assert.AreEqual(_getEmployeeByIdResponse.Birthdate, response.Birthdate);
            Assert.AreEqual(_getEmployeeByIdResponse.FullName, response.FullName);
            Assert.AreEqual(_getEmployeeByIdResponse.Id, response.Id);
            Assert.AreEqual(_getEmployeeByIdResponse.Tin, response.Tin);
            Assert.AreEqual(_getEmployeeByIdResponse.TypeId, response.TypeId);

            _employeeService.Verify(i => i.GetById(employeeId), Times.Once);
        }

        /// <summary>
        ///     Workflow:       Get All Employees
        ///     Scenario:       No Employee Found
        ///     Expected:       Returns 404 NotFound
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetEmployeeById_NoEmployeeFound_Returns404NotFound()
        {
            //Arrange
            int employeeId = 1;
            _employeeService.Setup(x => x.GetById(It.IsAny<int>())).Returns(new EmployeeDto());

            //Act
            var actionResult = await _target.GetById(employeeId);

            //Assert
            Assert.IsInstanceOf(typeof(ActionResult), actionResult);
            var objResult = actionResult as StatusCodeResult;
            Assert.AreEqual(404, objResult.StatusCode);

            _employeeService.Verify(i => i.GetById(employeeId), Times.Once);
        }

        private List<EmployeeDto> CreateEmployeesDto()
        {
            return new List<EmployeeDto>
            {
                new EmployeeDto
                {
                    Birthdate = DateTime.Now.ToString(),
                    FullName = "Test",
                    Id = 1,
                    Tin = "Test",
                    TypeId = (int)EmployeeType.Contractual
                },
                new EmployeeDto
                {
                    Birthdate = DateTime.Now.ToString(),
                    FullName = "Test2",
                    Id = 2,
                    Tin = "Test2",
                    TypeId = (int)EmployeeType.Regular
                },
            };
        }

        private EmployeeDto CreateEmployeeDto()
        {
            return new EmployeeDto
            {
                Birthdate = DateTime.Now.ToString(),
                FullName = "Test",
                Id = 1,
                Tin = "Test",
                TypeId = (int)EmployeeType.Contractual
            };
        }
    }
}