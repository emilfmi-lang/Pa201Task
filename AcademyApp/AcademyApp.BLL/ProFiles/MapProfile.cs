using AcademyApp.BLL.Dtos.Groups;
using AcademyApp.Core.Models;

namespace AcademyApp.BLL.ProFiles
{
    internal class MapProfile
    {
        public static GroupReturnDto GroupToGroupReturnDto(Group group)
        {
            return new GroupReturnDto()
            {
                Name = group.Name,
                Description = group.Description,
                Limit = group.Limit,
            };
        }
        public static Group GroupCreateToGroup(GroupCreateDto groupCreateDto)
        {
            return new Group()
            {
                Name = groupCreateDto.Name,
                Description = groupCreateDto.Description,
                Limit = groupCreateDto.Limit,
            };
        }

    }
}
