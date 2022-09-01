using Sten_saks_papir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sten_saks_papir.Repo
{
    public class MatchRepo
    {
        private List<Match> _m = new List<Match>();
        private PlayerRepo _p = new PlayerRepo();
        private static Random r = new Random();

        // Read all
        public List<Match> ReadAllMatches()
        {
            return _m;
        }

        // Read
        public Match FindMatch(string Id)
        {
            do
            {
                Match match = _m.Find(x => x.Id == Id);

                return match;
            }
            while (Id != null);
        }

        // Create player
        public Match Save(Match match)
        {
            do
            {
                if (match == null)
                {
                    match.Id = "computer-is-ready";
                }
                _m.Add(match);
                _p.Save(match.Player1);

                return match;
            }
            while (match != null);
        }
    }
}