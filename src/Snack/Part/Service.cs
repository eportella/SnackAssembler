using System;

namespace SnackAssembler.Snack.Part
{
    public class Service
    {
        internal Service() { }
        public Action Continue { get; internal set; }
        public bool Continued { get; internal set; }
    }
}