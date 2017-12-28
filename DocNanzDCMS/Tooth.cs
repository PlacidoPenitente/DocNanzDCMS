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

        public string ToothNo { get => toothNo; set => toothNo = value; }
        public string Image { get => image; set => image = value; }
        public List<Procedure> Procedures { get => procedures; set => procedures = value; }
    }
}
