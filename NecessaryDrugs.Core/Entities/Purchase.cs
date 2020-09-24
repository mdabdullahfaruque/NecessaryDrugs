using System;
using System.Collections.Generic;
using System.Text;

namespace NecessaryDrugs.Core.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public Stock stocks { get; set; }

    }
}
