using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class DentalChart
    {
        private List<Tooth> teeth = new List<Tooth>();

        public List<Tooth> Teeth { get => teeth; set => teeth = value; }
    }
}
