using System.Collections.Generic;

namespace SnackAssembler.Layer.BigMac
{
    public class Lettuce : Interface
    {
        IList<string> Messages { get; }
        public Lettuce(IList<string> messages)
        {
            Messages = messages;
        }
        public void StickIn(Snack.Part.Service model)
        {
            Messages.Add(nameof(Lettuce));
            model.Next();
            Messages.Add(nameof(Lettuce));
        }
    }
}
