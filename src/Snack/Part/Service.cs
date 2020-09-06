using System;

namespace SnackAssembler.Snack.Part
{
    public class Service
    {
        internal Service() { }
        public Action Next { get; internal set; }
    }
}