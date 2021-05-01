using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guden.Core.Entities.Concrete.Core
{
    public class Core_MenuOperationClaimRel:IEntity
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int OperationClaimId { get; set; }
        public int Status { get; set; }
    }
}
