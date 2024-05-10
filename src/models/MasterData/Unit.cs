using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.MasterData
{
    public class Unit
    {   
        
        public string? Name { get; set; }
        public bool IsSi { get; set; }

        public string? SiUnit { get; set; }
        public float SiRatio { get; set; }
    }


}
