using System.Collections.Generic;

namespace SnackAssembler.Layer.BigMac
{
    class Hambuger : Interface
    {
        IList<string> Messages { get; }
        public Hambuger(IList<string> messages)
        {
            Messages = messages;
        }

        public void StickIn(Snack.Part.Service part)
        {
            Messages.Add(nameof(Hambuger));
            part.Next();
        }
    }
}
