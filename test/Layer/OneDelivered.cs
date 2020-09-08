namespace SnackAssembler.Layer
{
    internal class OneDelivered : Interface
    {
        public void StickIn(Snack.Part.Service part)
        {
            part.Continue();
        }
    }
}