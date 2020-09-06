namespace SnackAssembler.Layer
{
    internal class ManyDelivered : Interface
    {
        public void StickIn(Snack.Part.Service  part)
        {
            part.Next();
            part.Next();
        }
    }
}