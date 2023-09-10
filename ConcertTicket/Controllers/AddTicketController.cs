using AutoMapper;
using Data.Repository.GenericRepository;
using Data.Repository.IGenericRepository;
using DTOs;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebFramework.BaseController;

namespace ConcertTicket.Controllers;

public class AddTicketController : BaseController
{
    private readonly IRepository<Ticket> _repository;
    private readonly IMapper _mapper;

    public AddTicketController(IRepository<Ticket> repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> Create(TicketDto dto)
    {
        var ticket = _mapper.Map<Ticket>(dto);
        await _repository.AddAsync(ticket , new CancellationToken(),true);
        var result = _mapper.Map<TicketSelectDto>(ticket);
        return Ok(result);
    }
}