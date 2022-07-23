using WebAppUniversity.Domain;

namespace WebAppUniversity.Dto
{
    public static class GroupDtoExtensions
    {
        public static Group ConvertToGroup(this GroupDto group)
        {
            return new Group
            {
                Id = group.Id,
                Name = group.Name,
                FacultyId = group.FacultyId
            };
        }

        public static GroupDto ConvertToGroupDto(this Group groupDto)
        {
            return new GroupDto
            {
                Id = groupDto.Id,
                Name = groupDto.Name,
                FacultyId = groupDto.FacultyId
            };
        }
    }
}