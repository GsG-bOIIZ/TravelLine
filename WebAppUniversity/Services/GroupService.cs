using WebAppUniversity.Domain;
using WebAppUniversity.Dto;
using WebAppUniversity.Repositories;

namespace WebAppUniversity.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public List<Group> GetGroupes()
        {
            return _groupRepository.GetGroupes();
        }

        public int CreateGroup(GroupDto group)
        {
            if (group == null)
            {
                throw new Exception($"{nameof(group)} not found");
            }

            Group groupEntity = group.ConvertToGroup();

            return _groupRepository.Create(groupEntity);
        }

        public void DeleteGroup(int groupId)
        {
            Group group = _groupRepository.Get(groupId);
            if (group == null)
            {
                throw new Exception($"{nameof(group)} not found, #Id - {groupId}");
            }

            _groupRepository.Delete(group);
        }

        public Group GetGroup(int groupId)
        {
            Group group = _groupRepository.Get(groupId);
            if (group == null)
            {
                throw new Exception($"{nameof(group)} not found, #Id - {groupId}");
            }

            return group;
        }
    }
}
