using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message) { }

        public EntityNotFoundException(string tableName, object primaryKey) :
            base($"No record found in the {tableName} table with primary key {primaryKey}.") { }
    }
}
