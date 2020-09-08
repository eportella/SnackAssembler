using System.Collections.Generic;

namespace SnackAssembler.Layer.XEgg
{
    class Bread : Interface
    {
        IList<string> Messages { get; }
        public Bread(IList<string> messages)
        {
            Messages = messages;
        }
        public void StickIn(Snack.Part.Service part)
        {
            Messages.Add(nameof(Bread) + 0);
            part.Continue();
            Messages.Add(nameof(Bread) + 1);
        }
    }
}