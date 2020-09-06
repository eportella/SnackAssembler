using System.Security.Authentication;

namespace SnackAssembler.Layer.MultiLayerExceptionFilter
{
    public class ThrowAutenthicate : Interface
    {
        public void StickIn(Snack.Part.Service part)
        {
            throw new AuthenticationException("CustomMessageAuthenticateException");
        }
    }
}
