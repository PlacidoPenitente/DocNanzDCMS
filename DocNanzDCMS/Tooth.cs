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
        private string condition;

        public string ToothNo { get => toothNo; set => toothNo = value; }
        public string Image { get => image; set => image = value; }
        public List<Procedure> Procedures { get => procedures; set => procedures = value; }
        public string Condition { get => condition; set => condition = value; }
    }
}
