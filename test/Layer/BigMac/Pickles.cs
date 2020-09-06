using System.Collections.Generic;

namespace SnackAssembler.Layer.BigMac
{
    class Pickles : Interface
    {
        IList<string> Messages { get; }
        public Pickles(IList<string> messages)
        {
            Messages = messages;
        }
        public void StickIn(Snack.Part.Service part)
        {
            Messages.Add(nameof(Pickles));
            part.Next();
        }
    }
}
