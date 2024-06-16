using HG.Web.Models;
using HG.Web.Service;
using HG.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HG.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService ?? throw new ArgumentNullException(nameof(menuService));
        }

        public async Task<IActionResult> GetMenu()
        {
			List<MenueResponseDto>? list = new();

			ResponseDto? response = await _menuService.GetMenuByUserIdAsync(null);

			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<MenueResponseDto>>(Convert.ToString(response.Result));
			}
			else
			{
				TempData["error"] = response?.Message;
			}
			return View(list);
		}
    }
}
