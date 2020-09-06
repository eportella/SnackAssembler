using System;

namespace SnackAssembler
{
    public class Service : Interface
    {
        public Action Assemble { get; internal set; }
    }
}