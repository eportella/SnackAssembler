using System.Collections.Generic;

namespace SnackAssembler.Layer.XEgg
{
    class Cheese : Interface
    {
        IList<string> Messages { get; }
        public Cheese(IList<string> messages)
        {
            Messages = messages;
        }
        public void StickIn(Snack.Part.Service part)
        {
            Messages.Add(nameof(Cheese));
            part.Next();
        }
    }
}