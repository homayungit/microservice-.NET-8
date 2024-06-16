using HG.Web.Models;

namespace HG.Web.Service.IService
{
    public interface ICompanyService
    {
        Task<ResponseDto?> GetCompanyAsync(string couponCode);
        Task<ResponseDto?> GetAllCompaniesAsync();
        Task<ResponseDto?> GetCompanyByIdAsync(int id);
        Task<ResponseDto?> CreateCompaniesAsync(CompanyDto companyDto);
        Task<ResponseDto?> UpdateCompaniesAsync(CompanyDto companyDto);
        Task<ResponseDto?> DeleteCompanyAsync(int id);
    }
}
