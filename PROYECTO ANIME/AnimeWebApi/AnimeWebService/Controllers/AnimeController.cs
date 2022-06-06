using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibreriaAnime;

namespace AnimeWebApi.AnimeWebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeController : Controller
    {
    private readonly ILogger<AnimeController> _logger;
    private readonly Repositorio _repository;
    public AnimeController(ILogger<AnimeController> logger)
    {
        _logger = logger;
        _repository = new Repositorio();
        _repository.LoadFile(@"C:\Users\dulso\OneDrive\Documentos\Anime\TablaAnime.csv");
    }

    [HttpGet]
    [Route("GetAnimes")]
    public IEnumerable<Anime> GetAnimes()
    {
        return _repository.GetAll();
    }

    [HttpGet]
    [Route("GetAnimeByTitulo")]
    public IEnumerable<Anime> GetAnimes(String title)
    {
       // _logger.Log("Leyendo movies por nombre");
        return _repository.GetAnimeByTitulo(title);
    }



        // GET: AnimeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AnimeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnimeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnimeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnimeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnimeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnimeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnimeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
