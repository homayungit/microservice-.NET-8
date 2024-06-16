using HG.Web.Models;
using HG.Web.Service.IService;
using HG.Web.Utility;

namespace HG.Web.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IBaseService _baseService;

        public CompanyService(IBaseService baseService)
        {
            _baseService = baseService ?? throw new ArgumentNullException(nameof(baseService));
        }

        public async Task<ResponseDto?> CreateCompaniesAsync(CompanyDto companyDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = companyDto,
                Url = StaticDetails.ConfigAPIBase + "/api/company"
            });
        }

        public async Task<ResponseDto?> DeleteCompanyAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.ConfigAPIBase + "/api/company/" + id
            });
        }

        public async Task<ResponseDto?> GetAllCompaniesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ConfigAPIBase + "/api/company"
            });
        }

        public async Task<ResponseDto?> GetCompanyAsync(string shortCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ConfigAPIBase + "/api/company/GetByCode/" + shortCode
            });
        }

        public Task<ResponseDto?> GetCompanyByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateCompaniesAsync(CompanyDto companyDto)
        {
            throw new NotImplementedException();
        }
    }
}
