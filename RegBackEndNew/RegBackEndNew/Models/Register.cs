using System;
using System.Collections.Generic;

namespace RegBackEndNew.Models
{
    public partial class Register
    {
        public int Id { get; set; }
        public string RegCode { get; set; }
        public string RegName { get; set; }
        public int RegAge { get; set; }
    }
}
