using AcademyApp.BLL.Dtos.Groups;
using AcademyApp.Core.Models;

namespace AcademyApp.BLL.Interfaces
{
    public interface IGroupServices
    {
        void AddGroup(GroupCreateDto groupCreateDto);
        Task AddGroupAsync(GroupCreateDto groupCreateDto);
        List<Group> GetAllGroups();
        Task<List<Group>> GetAllGroupsAsync();
        GroupReturnDto GetGroupById(int id);
        Task<GroupReturnDto> GetGroupByIdAsync(int id);
        List<Group> GetGroupsByLimit(int limit);
        Task<List<Group>> GetGroupsByLimitAsync(int limit);
        List<Group> GetSearchByName(string name);
        Task<List<Group>> GetSearchByNameAsync(string name);
        List<Group> LimitByGroups(int minLimit, int maxLimit);
        Task<List<Group>> LimitByGroupsAsync(int minLimit, int maxLimit);

        Task UpdateGroupAsync(Group group);
        void UpdateGroup(Group group);
    }
}