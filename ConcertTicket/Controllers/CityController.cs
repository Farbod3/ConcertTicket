using System.Linq.Expressions;
using AutoMapper;
using Data.Repository.IGenericRepository;
using DTOs;
using Entities;
using Iran.AspNet.CountryDivisions;
using Iran.AspNet.CountryDivisions.Data.Models;
using Microsoft.AspNetCore.Mvc;
using WebFramework.BaseController;

namespace ConcertTicket.Controllers;

public class CityController : BaseController
{
    private readonly IRepository<City> _repository;
    private readonly IMapper _mapper;
    private readonly IIranCountryDivisions _iranCountryDivisions;

    public CityController(IRepository<City> repository,IMapper mapper, IIranCountryDivisions iranCountryDivisions)
    {
        _repository = repository;
        _mapper = mapper;
        _iranCountryDivisions = iranCountryDivisions;
    }

    [HttpPost]
    public async Task<ActionResult> CreateCity( CityDto dto)
    {
        var request = _mapper.Map<City>(dto);
        await _repository.AddAsync(request,new CancellationToken(),true);
        var result = _mapper.Map<CitySelectDto>(request);
        return new JsonResult(result);
    }

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<CityDto>>> GetCities( )
    // {
    //       await _iranCountryDivisions.GetOstansAsync();
    //       await _iranCountryDivisions.GetOstansAsync();
    //       return Ok();
    //
    // }
    [HttpGet]
    public ActionResult<IEnumerable<CityDto>> GetProvinces()
    {
        var provinces = _iranCountryDivisions.GetOstans();
        var cities = _iranCountryDivisions.GetShahrestans();
        return Ok(cities);
    }

    // [HttpGet("{provinceId}/cities")]
    // public ActionResult<IEnumerable<CityDto>> GetCitiesByProvince(Expression<Func<Shahr, bool>> city)
    // {
    //     var cities = _iranCountryDivisions.GetShahrs(city);
    //     return Ok(cities);
    // }

  
    // [HttpPost]
    // public Task<ActionResult> AddCity(CityDto dto)
    // {
    //     _repositZory.AddAsync(dto, new CancellationToken(),true)
    // }

}