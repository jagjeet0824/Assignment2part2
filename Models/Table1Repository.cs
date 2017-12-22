using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models
{

    // repository for mock album data for unit testing
   public interface Table1Repository
    {
        IQueryable<Table1> Table1 { get; }
        Table1 Save(Table1 table1);
        void Delete(Table1 table1);
        
    }
}
