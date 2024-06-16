using HG.Web.Models;

namespace HG.Web.Service.IService
{
    public interface IMenuService
    {
        Task<ResponseDto?> GetMenuByUserIdAsync(int? userId);
    }
}
