using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sten_saks_papir.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public string Option { get; set; }
        public bool IsAlone { get; set; }
    }
}