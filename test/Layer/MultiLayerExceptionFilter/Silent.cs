using System.Collections.Generic;
using System.Security.Cryptography;

namespace SnackAssembler.Layer.MultiLayerExceptionFilter
{
    class Silent : Interface
    {
        IList<string> Messages { get; }
        public Silent(IList<string> messages)
        {
            Messages = messages;
        }
        public void StickIn(Snack.Part.Service part)
        {
            try
            {
                part.Next();
            }
            catch { Messages.Add(nameof(Silent)); }
            finally { }
        }
    }
}