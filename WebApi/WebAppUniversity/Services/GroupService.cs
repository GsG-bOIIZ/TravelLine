using WebAppUniversity.Domain;
using WebAppUniversity.Dto;
using WebAppUniversity.Repositories;
using WebAppUniversity.UnitOfWork;

namespace WebAppUniversity.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GroupService(IGroupRepository groupRepository, IUnitOfWork unitOfWork)
        {
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;
        }

        public List<Group> GetGroupes()
        {
            return _groupRepository.GetGroups();
        }

        public int CreateGroup(GroupDto group)
        {
            if (group == null)
            {
                throw new Exception($"{nameof(group)} not found");
            }

            Group groupEntity = group.ConvertToGroup();

            int id = _groupRepository.Create(groupEntity).Id;
            _unitOfWork.Commit();

            return id;
        }

        public void DeleteGroup(int groupId)
        {
            Group group = _groupRepository.Get(groupId);
            if (group == null)
            {
                throw new Exception($"{nameof(group)} not found, #Id - {groupId}");
            }

            _groupRepository.Delete(group);
            _unitOfWork.Commit();
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
        
        public int UpdateGroup(GroupDto groupDto)
        {
            if (groupDto == null)
            {
                throw new Exception($"{nameof(groupDto)} not found");
            }
            
            Group groupEntity = groupDto.ConvertToGroup();

            _groupRepository.Update( groupEntity );
            _unitOfWork.Commit();
            
            return groupEntity.Id;
        }
    }
}
