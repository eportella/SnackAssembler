using System.Collections.Generic;

namespace SnackAssembler.Layer.BigMac
{
    class SpecialSauce : Interface
    {
        IList<string> Messages { get; }
        public SpecialSauce(IList<string> messages)
        {
            Messages = messages;
        }
        public void StickIn(Snack.Part.Service part)
        {
            Messages.Add(nameof(SpecialSauce));
            part.Next();
        }
    }
}
