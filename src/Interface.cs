using System;
using System.Runtime.CompilerServices;

namespace SnackAssembler
{
    public interface Interface
    {
        Action Assemble { get; }
        public static Service Plan(Desktop.Service desktop)
        {
            if (desktop?.Layers == default)
                throw new Impossible.Service { };

            if (!desktop.Layers.TryDequeue(out Layer.Interface layer))
                return new Service { Assemble = () => { } };

            return new Service
            {
                Assemble = Assemble(desktop, layer)
            };

            static Action Assemble(Desktop.Service desktop, Layer.Interface layer)
            {
                return () =>
                {
                    var part = new Snack.Part.Service
                    {
                        Continued = default,
                    };
                    Continue(desktop, part);

                    layer.StickIn(part);

                    if (!part.Continued)
                        throw new Impossible.Service { };
                };

                static void Continue(Desktop.Service desktop, Snack.Part.Service part)
                {
                    part.Continue = () =>
                    {
                        if (part.Continued)
                            throw new Impossible.Service { };
                        part.Continued = true;
                        Plan(desktop).Assemble();
                    };
                }
            }
        }
    }
}