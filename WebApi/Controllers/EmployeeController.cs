using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public async IEnumerable<EmployeeDto> GetAll()
        {
            var items = await _employeeService.GetAllEmployees();
            return _mapper.Map<IEnumerable<EmployeeDto>>(items);
        }

        // GET api/<controller>/5
        public async EmployeeDto Get(string employeeCode)
        {
            var item = await _employeeService.GetEmployeeByCode(employeeCode);
            return _mapper.Map<EmployeeDto>(item);
        }

        // POST api/<controller>
        public async bool Post(EmployeeDto employeeDto)
        {
            var result = await _employeeService.SaveEmployeeDetails(_mapper.Map<EmployeeInfo>(employeeDto));
            return result;
        }

    }
}
