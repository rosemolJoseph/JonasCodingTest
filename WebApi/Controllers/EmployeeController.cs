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
        private readonly ILogger _logger;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper, ILogger logger)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _logger = logger;
        }
        // GET api/<controller>
        public async IEnumerable<EmployeeDto> GetAll()
        {
        try{
            var items = await _employeeService.GetAllEmployees();
            return _mapper.Map<IEnumerable<EmployeeDto>>(items);
            }
            catch(Exception e)
            {
            _logger.log("Exception",e);
            }
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
