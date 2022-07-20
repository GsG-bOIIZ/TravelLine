using WebAppUniversity.Domain;

namespace WebAppUniversity.Repositories
{
    public interface IGroupRepository
    {
        public List<Group> GetGroupes();
        public int Create(Group group);
        public void Delete(Group group);
        public Group Get(int id);
        public int Update(Group group);
    }
}
