using WebAppUniversity.Domain;

namespace WebAppUniversity.Repositories
{
    public interface IGroupRepository
    {
        List<Group> GetGroups();
        Group? Get(int id);
        Group Create(Group group);
        void Delete(Group group);
        void Update(Group group);
    }
}
