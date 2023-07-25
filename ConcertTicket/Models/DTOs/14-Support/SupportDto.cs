using Entities;
using WebFramework.Mapper;

namespace DTOs;

public class SupportDto : BaseDto<Support,SupportDto,long>
{
    public int PhoneNumber { get; set; }
    public string Description { get; set; }
    public string LOcation { get; set; }
    public string Email { get; set; }
}