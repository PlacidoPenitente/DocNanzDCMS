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

        private List<string> procedures = new List<string>();
        public string Image { get => image; set => image = value; }
    }
}
