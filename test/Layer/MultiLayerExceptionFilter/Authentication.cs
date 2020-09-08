using System;
using System.Collections.Generic;
using System.Security.Authentication;

namespace SnackAssembler.Layer.MultiLayerExceptionFilter
{
    class Authentication : Interface
    {
        IList<string> Messages { get; }
        public Authentication(IList<string> messages)
        {
            Messages = messages;
        }
        public void StickIn(Snack.Part.Service part)
        {
            try
            {
                part.Continue();
            }
            catch (AuthenticationException e)
            {
                Messages.Add(e.Message);
                throw;
            }
        }
    }
}