using System.Collections.Generic;
using System.Linq;

namespace SnackAssembler.Desktop
{
    public interface Interface
    {
        static Service PickUpAll(params Layer.Interface[] @params) =>
            new Service(new Queue<Layer.Interface>(@params?.Where(w => w != default) ?? Enumerable.Empty<Layer.Interface>()));
    }
}
