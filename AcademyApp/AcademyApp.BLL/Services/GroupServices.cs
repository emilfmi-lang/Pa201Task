using AcademyApp.BLL.Dtos.Groups;
using AcademyApp.BLL.Interfaces;
using AcademyApp.BLL.ProFiles;
using AcademyApp.Core.Models;
using AcademyApp.DLL.Data;
using AcademyApp.DLL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApp.BLL.Services
{
    public class GroupServices : IGroupServices
    {
        private readonly IRepository<Group> _repo;

        public GroupServices(IRepository<Group> repo)
        {
            _repo = repo;
        }

        public void AddGroup(GroupCreateDto groupCreateDto)
        {
            var groupExists = _academyDbcontext.Groups.Any(x => x.Name.ToLower() == groupCreateDto.Name.ToLower());
            if (groupExists)
            {
                throw new Exception("Group not found");
            }
            var data = MapProfile.GroupCreateToGroup(groupCreateDto);
            _academyDbcontext.Groups.Add(data);
            _academyDbcontext.SaveChanges();
        }
        public async Task AddGroupAsync(GroupCreateDto groupCreateDto)
        {
            var groupExists = await _academyDbcontext.Groups.AnyAsync(x => x.Name.ToLower() == groupCreateDto.Name.ToLower());
            if (groupExists)
            {
                throw new Exception("Group not found");
            }
            Group group = new Group()
            {
                Name = groupCreateDto.Name,
                Description = groupCreateDto.Description,
                Limit = groupCreateDto.Limit,
            };
            await _academyDbcontext.Groups.AddAsync(group);
            await _academyDbcontext.SaveChangesAsync();
        }

        public List<Group> GetAllGroups() => _academyDbcontext.Groups.ToList();

        public async Task<List<Group>> GetAllGroupsAsync() => await _academyDbcontext.Groups.ToListAsync();

        public GroupReturnDto GetGroupById(int id)
        {
            var data = _academyDbcontext.Groups.Find(id);
            if (data is null)
            {
                throw new Exception("Group not found.");
            }
          
            return MapProfile.GroupToGroupReturnDto(data);
        }
        public async Task<GroupReturnDto> GetGroupByIdAsync(int id)
        {
            var data = await _academyDbcontext.Groups.FindAsync(id);
            if (data is null)
            {
                throw new Exception("Group not found.");
            }
            return MapProfile.GroupToGroupReturnDto(data);
        }

        public List<Group> GetSearchByName(string name) =>

        _academyDbcontext.Groups.Where(x => x.Name.ToLower().Contains(name.ToLower())
                               || x.Description.ToLower().Contains(name.ToLower())).ToList();

        public async Task<List<Group>> GetSearchByNameAsync(string name) =>

        await _academyDbcontext.Groups.Where(x => x.Name.ToLower().Contains(name.ToLower())
                               || x.Description.ToLower().Contains(name.ToLower())).ToListAsync();

        public List<Group> GetGroupsByLimit(int limit) =>
            _academyDbcontext.Groups.Where(x => x.Limit == limit).ToList();

        public async Task<List<Group>> GetGroupsByLimitAsync(int limit) =>
           await _academyDbcontext.Groups.Where(x => x.Limit == limit).ToListAsync();

        public List<Group> LimitByGroups(int minLimit, int maxLimit)
        {
            return _academyDbcontext.Groups.Where(x => x.Limit > minLimit && x.Limit < maxLimit).ToList();
        }

        public async Task<List<Group>> LimitByGroupsAsync(int minLimit, int maxLimit)
        {
            return await _academyDbcontext.Groups.Where(x => x.Limit > minLimit && x.Limit < maxLimit).ToListAsync();
        }

        public void UpdateGroup(Group group)
        {
            var data = _academyDbcontext.Groups.Find(group.Id);
            if (data == null)
                throw new Exception("Group not found");
            if (_academyDbcontext.Groups.Any(x => x.Name.ToLower() == group.Name.ToLower() && x.Id != data.Id))
                throw new Exception("Another group with the same name already exists");
            data.Name = group.Name;
            data.Description = group.Description;
            data.Limit = group.Limit;
        }
        public async Task UpdateGroupAsync(Group group)
        {
            var data = await _academyDbcontext.Groups.FindAsync(group.Id);
            if (data == null)
                throw new Exception("Group not found");
            if (await _academyDbcontext.Groups.AnyAsync(x => x.Name.ToLower() == group.Name.ToLower() && x.Id != data.Id))
                throw new Exception("Another group with the same name already exists");
            data.Name = group.Name;
            data.Description = group.Description;
            data.Limit = group.Limit;
            await _academyDbcontext.SaveChangesAsync();
        }
    }
}
