using HG.Web.Models;
using HG.Web.Service.IService;
using HG.Web.Utility;

namespace HG.Web.Service
{
    public class MenuService : IMenuService
    {
        private readonly IBaseService _baseService;

        public MenuService(IBaseService baseService)
        {
            _baseService = baseService ?? throw new ArgumentNullException(nameof(baseService));
        }

        public async Task<ResponseDto?> GetMenuByUserIdAsync(int? userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.MenuApiBase + "/api/permission/GetMenue/" + userId
            });
        }
    }
}
