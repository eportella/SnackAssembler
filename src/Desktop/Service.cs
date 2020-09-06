using System.Collections.Generic;

namespace SnackAssembler.Desktop
{
    public class Service : Interface
    {
        public Queue<Layer.Interface> Layers { get; }
        public Service(Queue<Layer.Interface> queue)
        {
            Layers = queue;
        }
    }
}