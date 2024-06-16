namespace HG.Web.Models
{
    public class MenueResponseDto
    {
        public int MenueId { get; set; }

        public string MenuName { get; set; } = null!;

        public int ParentId { get; set; }


        public bool IsActive { get; set; }
        public int MenueMappingId { get; set; }

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public int ModuleId { get; set; }


    }
}
