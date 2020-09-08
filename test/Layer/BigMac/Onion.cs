using System.Collections.Generic;

namespace SnackAssembler.Layer.BigMac
{
    class Onion : Interface
    {
        IList<string> Messages { get; }
        public Onion(IList<string> messages)
        {
            Messages = messages;
        }
        public void StickIn(Snack.Part.Service part)
        {
            Messages.Add(nameof(Onion));
            part.Continue();
        }
    }
}
