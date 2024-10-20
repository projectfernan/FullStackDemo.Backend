using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackDemo.Domain.Entities.Athentication
{
    public class UserBasicAuth : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
