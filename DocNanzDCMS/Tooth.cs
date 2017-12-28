using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class Tooth
    {
        private string toothNo;
        private string image;

        private List<Procedure> procedures = new List<Procedure>();
        public string Image { get => image; set => image = value; }
    }
}
