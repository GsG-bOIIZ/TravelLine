using WebAppUniversity.Domain;
using WebAppUniversity.Dto;

namespace WebAppUniversity.Services
{
    public interface IGroupService
    {
        public List<Group> GetGroupes();
        public int CreateGroup(GroupDto group);
        public void DeleteGroup(int groupId);
        public Group GetGroup(int groupId);
        public int UpdateGroup(GroupDto groupDto);
    }
}
