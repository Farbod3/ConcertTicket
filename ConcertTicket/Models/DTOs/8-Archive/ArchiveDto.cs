using Entities;
using WebFramework.Mapper;

namespace DTOs;

public class ArchiveDto : BaseDto<Archive , ArchiveDto , long>
{
    public string Title { get; set; }
}