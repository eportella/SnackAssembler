using System.Collections.Generic;

namespace SnackAssembler.Layer.XEgg
{
    class Egg : Interface
    {
        IList<string> Messages { get; }
        public Egg(IList<string> messages)
        {
            Messages = messages;
        }
        public void StickIn(Snack.Part.Service part)
        {
            Messages.Add(nameof(Egg));
            part.Continue();
        }
    }
}