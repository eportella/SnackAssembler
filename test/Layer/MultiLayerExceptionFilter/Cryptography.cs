using System.Collections.Generic;
using System.Security.Cryptography;

namespace SnackAssembler.Layer.MultiLayerExceptionFilter
{
    class Cryptography : Interface
    {
        IList<string> Messages { get; }
        public Cryptography(IList<string> messages)
        {
            Messages = messages;
        }
        public void StickIn(Snack.Part.Service part)
        {
            try
            {
                part.Next();
            }
            catch (CryptographicException e)
            {
                Messages.Add(e.Message);
                throw;
            }
        }
    }
}