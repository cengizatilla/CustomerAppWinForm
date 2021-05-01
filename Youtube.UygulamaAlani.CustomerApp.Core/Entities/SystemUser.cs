using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.UygulamaAlani.CustomerApp.Core.Entities
{
    public sealed class SystemUser : BaseClass
    {

        public string UserName { get; set; }
        public string Pass { get; set; }
    }
}
