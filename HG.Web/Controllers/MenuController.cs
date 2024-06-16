using HG.Web.Models;
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
            int id = 0;
            List<MenueResponseDto>? list = new();
            try
            {
               
                ResponseDto? response = await _menuService.GetMenuByUserIdAsync(id);
                if (response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<MenueResponseDto>>(Convert.ToString(response.Result));
                }
            }
            catch (Exception ex)
            {

                throw;
            }            

            return View(list);
        }
    }
}
