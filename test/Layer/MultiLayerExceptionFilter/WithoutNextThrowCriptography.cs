using System;
using System.Security.Cryptography;

namespace SnackAssembler.Layer.MultiLayerExceptionFilter
{
    public class WithoutNextThrowCriptography : Interface
    {
        public void StickIn(Snack.Part.Service part)
        {
            throw new CryptographicException();
        }
    }
}
