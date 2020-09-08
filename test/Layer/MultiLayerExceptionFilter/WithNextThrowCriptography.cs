using System.Security.Cryptography;

namespace SnackAssembler.Layer.MultiLayerExceptionFilter
{
    public class WithNextThrowCriptography : Interface
    {
        public void StickIn(Snack.Part.Service part)
        {
            part.Continue();
            throw new CryptographicException();
        }
    }
}
