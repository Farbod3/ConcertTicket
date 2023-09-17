using AutoMapper;
using Data.Repository.IGenericRepository;
using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebFramework.BaseController;

namespace ConcertTicket.Controllers;

public class AddConcertController : BaseController
{
    private readonly IRepository<Concert> _repository;
    private readonly IMapper _mapper;

    public AddConcertController(IRepository<Concert> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> AddConcert(CocertDto dto)
    {
        var map = _mapper.Map<Concert>(dto);
        await _repository.AddAsync(map,new CancellationToken(),true);
        var map2 = _mapper.Map<ConcertSelectDto>(map);
        return new JsonResult(map2);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConcertSelectDto>>> GetConcerts()
    {
        var concert =  _repository.GetAllASync(new CancellationToken());
        var concertdto = _mapper.Map<IEnumerable<ConcertSelectDto>>(concert);
        return new JsonResult(concertdto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ConcertSelectDto>> GetConcertId(int id)
    {
        var concert = await _repository.GetByIdAsync(id);
        if (concert == null)
        {
            return NotFound();
        }
        var concertDto = _mapper.Map<ConcertSelectDto>(concert);
        return new JsonResult(concertDto);
    }
    // [HttpGet]
    // public async 

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteConcert(int id)
    {
        var concert = await _repository.GetByIdAsync(id);
        if (concert == null)
        {
            return NotFound();
        }
        await _repository.DeleteAsync(concert, new CancellationToken());
        return NoContent();
    }
}