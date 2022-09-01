using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuveytTurk.CORE.Dtos
{
    public class DeleteDto
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
