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
    private readonly IRepository<Concert> _concertRepository;
    private readonly IMapper _mapper;

    public AddTicketController(IRepository<Ticket> repository,IMapper mapper, IRepository<Concert> concertRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _concertRepository = concertRepository;
    }

    [HttpPost("{ConcertId}")]
    public async Task<ActionResult> CreateTicket(long ConcertId ,TicketDto dto)
    {
        var concert = await _concertRepository.GetByIdAsync(ConcertId);
        if (concert == null)
            return NotFound("نیست!");

        var ticket = new List<Ticket>();
        for (int i = 0; i < dto.Quantity; i++)
        {
            var ticketfor = new Ticket
            {
                ConcertId = ConcertId,
                IsActive = false
            };
            ticket.Add(ticketfor);
        }

        await _repository.AddRangeAsync(ticket, new CancellationToken());
        var ticketdto = _mapper.Map<IEnumerable<TicketDto>>(ticket);
        return new JsonResult(ticketdto);
        
        // var ticket = _mapper.Map<Ticket>(dto);
        // await _repository.AddAsync(ticket , new CancellationToken(),true);
        // var result = _mapper.Map<TicketSelectDto>(ticket);
        // return new JsonResult(result);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TicketSelectDto>>> GetTicket()
    {
        var tickets =  _repository.GetAllASync(new CancellationToken());
        var ticketdto = _mapper.Map<IEnumerable<TicketSelectDto>>(tickets);
        return new JsonResult(ticketdto);
    }
}