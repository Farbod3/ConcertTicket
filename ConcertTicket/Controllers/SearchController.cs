using System.Web.Http;
using Data.Repository.IGenericRepository;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stimulsoft.System.Windows.Forms;
using WebFramework.BaseController;

namespace ConcertTicket.Controllers;

public class SearchController : BaseController
{

    private readonly IRepository<Ticket> _repository;

    public SearchController(IRepository<Ticket> repository)
    {
        _repository = repository;
    }
    //
    // public async Task<IActionResult> Search(string ticket)
    // {
    //     
    // }
    // private readonly List<ConcertTicket> tickets = new List<ConcertTicket>
    // {
    //     new ConcertTicket { Id = 1, Title = "Concert tehran", Artist = "yas", Venue = "Tehran" },
    //     new ConcertTicket { Id = 2, Title = "Concert sanandaj", Artist = "hickas", Venue = "Sanadaj" },
    //     new ConcertTicket { Id = 3, Title = "Concert ramsar", Artist = "pishro", Venue = "Ramsar" }
    // };

    // [Microsoft.AspNetCore.Mvc.HttpGet]
    // [Microsoft.AspNetCore.Mvc.Route("search")]
    //
    // public async Task<OkObjectResult> Search(string query,int page = 1)
    // {
    //
    //     var results = tickets.Where(ticket =>
    //         ticket.Title.Contains(query) ||
    //         ticket.Artist.Contains(query) ||
    //         ticket.Venue.Contains(query)).ToList();
    //
    //     return Ok(results);
    // }
}

// public class ConcertTicket
// {
//     public int Id { get; set; }
//     public string Title { get; set; }
//     public string Artist { get; set; }
//     public string Venue { get; set; }
// }
 
