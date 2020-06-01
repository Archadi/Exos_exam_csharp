using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1
{
    public class TodoItemDTO
    {
        public long Id { set; get; }
        public string Name { set; get; }
        public bool IsComplete { set; get; }
    }
}
