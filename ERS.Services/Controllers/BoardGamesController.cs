﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ERS.Services.DataContext;
using ERS.Services.Models;

namespace ERS.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGamesController : ControllerBase
    {

        public class BoardGameController : Controller
        {
            private BoardGamesDBContext _context;

            public BoardGameController(BoardGamesDBContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult Index()
            {
                var games = _context.BoardGames.ToList();
                return View(games);
            }

            [HttpGet]
            public IActionResult Add()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Add(BoardGame game)
            {
                //Determine the next ID
                var newID = _context.BoardGames.Select(x => x.ID).Max() + 1;
                game.ID = newID;

                _context.BoardGames.Add(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            [HttpPost]
            public IActionResult Delete(int id)
            {
                _context.BoardGames.Remove(_context.BoardGames.Find(id));
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            [HttpGet]
            public IActionResult Edit(int id)
            {
                var game = _context.BoardGames.Find(id);
                return View(game);
            }

            [HttpPost]
            public IActionResult Edit(BoardGame game)
            {
                _context.BoardGames.Update(game);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
