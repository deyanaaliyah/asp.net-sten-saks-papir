using Sten_saks_papir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sten_saks_papir.Repo
{
    public class PlayerRepo
    {
        private List<Player> _p = new List<Player>();

        // Read all
        public List<Player> ReadAllPlayers()
        { 
            return _p;
        }

        // Read
        public Player FindPlayer(string Name)
        {
            do
            {
                Player player = _p.Find(x => x.Name == Name);

                return player;
            }
            while(Name != null);
        }

        // Create player
        public Player Save(Player player)
        {
            do
            {
                _p.Add(player);

                return player;
            }
            while (player != null);
        }

        // Update
        public Player Update(Player player, string Option)
        {
            do
            {
                var UpdatedPlayer = FindPlayer(player.Name);
                
                UpdatedPlayer = new Player
                {
                    Name = player.Name,
                    IsAlone = player.IsAlone,
                    Option = Option
                };

                _p.Remove(player);

                Save(UpdatedPlayer);

                return UpdatedPlayer;
            }
            while(player != null);
        }

        public Player Computer()
        {
            Random r = new Random();
            string[] Names = { "Rockslayer28", "Papergirl92", "Scissorboy19" };
            string[] Options = { "sten", "saks", "papir" };

            return new Player
            {
                Name = Names[r.Next(Names.Length)],
                Option = Options[r.Next(Options.Length)],
                IsAlone = true
            };
        }
    }
}