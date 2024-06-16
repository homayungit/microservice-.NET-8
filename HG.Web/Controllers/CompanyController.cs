using HG.Web.Models;
using HG.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HG.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
        }

        public async Task<IActionResult> CompanyIndex()
        {
			List<CompanyDto>? list = new();

			ResponseDto? response = await _companyService.GetAllCompaniesAsync();

			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CompanyDto>>(Convert.ToString(response.Result));
			}
			else
			{
				TempData["error"] = response?.Message;
			}
			return View(list);
        }
    }
}
