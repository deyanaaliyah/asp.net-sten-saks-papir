using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sten_saks_papir.Models
{
    public class Match
    {
        public string Id { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
    }
}