using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Controllers;

public class InterestedCandidatesController : Controller
{
    private readonly ICandidateService _candidateService;
    private readonly IVacancyService _vacancyService;
    private readonly IMapper _mapper;


    public InterestedCandidatesController(ICandidateService candidateService, IVacancyService vacancyService, IMapper mapper)
    {
        _candidateService = candidateService;
        _vacancyService = vacancyService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Index() //Falta implementar a lógica retornar apenas interessados (aqui ou no service?)
    {
        var candidates = await _candidateService.GetAll();

        if (candidates == null) return BadRequest();

        var candidatesModel = _mapper.Map<List<CandidateModel>>(candidates);

        return View(candidatesModel);       
    }
}
