using System.Collections.Generic;

namespace SnackAssembler.Layer.BigMac
{
    class SesameBread : Interface
    {
        IList<string> Messages { get; }
        public SesameBread(IList<string> messages)
        {
            Messages = messages;
        }
        public void StickIn(Snack.Part.Service part)
        {
            Messages.Add(nameof(SesameBread) + 0);
            part.Next();
            Messages.Add(nameof(SesameBread) + 1);
        }
    }
}