using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public async IEnumerable<CompanyDto> GetAll()
        {
            var items = await _companyService.GetAllCompanies();
            return _mapper.Map<IEnumerable<CompanyDto>>(items);
        }

        // GET api/<controller>/5
        public async CompanyDto Get(string companyCode)
        {
            var item = await _companyService.GetCompanyByCode(companyCode);
            return _mapper.Map<CompanyDto>(item);
        }

        // POST api/<controller>
        public async bool Post(CompanyDto companyDto)
        {
            var result = await _companyService.SaveCompanyDetails(_mapper.Map<CompanyInfo>(companyDto));
            return result;
        }

        // PUT api/<controller>/5
        public async bool Put(string companyCode, CompanyDto companyDto)
        {
            var result = await _companyService.SaveCompanyDetails(string companyCode, _mapper.Map<CompanyInfo>(companyDto));
            return result;
        }

        // DELETE api/<controller>/5
        public async bool Delete(string companyCode)
        {
            var result = await _companyService.DeleteCompanyDetails(string companyCode);
            return result;
        }
    }
}
