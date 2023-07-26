using Entities;
using WebFramework.Mapper;

namespace DTOs;

public class SupportSelectDto : BaseDto<Support,SupportSelectDto,long>
{
    public int PhoneNumber { get; set; }
    public string Description { get; set; }
    public string LOcation { get; set; }
    public string Email { get; set; }
}