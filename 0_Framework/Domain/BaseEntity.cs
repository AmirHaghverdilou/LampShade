using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Domain
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            UpdateTime = DateTime.Now;
        }
    }
}
