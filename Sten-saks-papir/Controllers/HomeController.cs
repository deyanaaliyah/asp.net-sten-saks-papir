using Sten_saks_papir.Models;
using Sten_saks_papir.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sten_saks_papir.Controllers
{
    public class HomeController : Controller
    {
        private PlayerRepo _p = new PlayerRepo();
        private MatchRepo _m = new MatchRepo();

        public ActionResult Index()
        {
            var Computer = _p.Computer();
            _m.Save(new Match { Player2 = Computer, Id = "hey" });
            var MatchList = _m.ReadAllMatches();

            return View(MatchList);
        }

        [HttpGet]
        public ActionResult Create() // Create
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Match match)
        {
            if(match == null)
            {
                ViewBag.Error = "Match empty";
                return View();
            }
            else
            {
                _m.Save(match);
                _p.Save(match.Player1);

                return View("Index");
            }

            //if(match.Player1.IsAlone)
            //{
            //    _m.Save(match);
            //    return View("StartGame", match);
            //}
            //else if (!match.Player1.IsAlone)
            //{
            //    return View("StartGameInit", match);
            //}
            //else
            //{
            //    ViewBag.Error = "Kunne ikke oprette spillet. Prøv venligst igen.";
            //    return View("StartMatch");
            //}
        }
        
        [ActionName("/")]
        [HttpPut]
        public ActionResult UpdateOption(Match match)
        {
            if(match != null)
            {
                _p.Update(match.Player1, match.Player1.Option);
            }

            return View(match);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sten, saks, papir er et spil";

            return View();
        }
    }
}