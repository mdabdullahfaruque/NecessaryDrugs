using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NecessaryDrugs.Web.Areas.Admin.Models
{
    public class CategoryUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        internal void AddNewCaregory()
        {
            throw new NotImplementedException();
        }
    }
}
