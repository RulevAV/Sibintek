using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sibintek.Domain.Entities
{
    public class BaseEntities
    {
        public BaseEntities() => DateAdd = DateTime.Now;

        [Key]
        public int Id { get; set; }
        [DataType(DataType.Time)]
        public DateTime DateAdd { get; set; }
    }
}
