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
                Assemble = () =>
                {
                    var part = new Snack.Part.Service
                    {
                        Assembled = default,
                    };
                    
                    part.Next = () =>
                    {
                        if (part.Assembled)
                            throw new Impossible.Service { };
                        part.Assembled = true;
                        Plan(desktop).Assemble();
                    };

                    layer.StickIn(part);

                    if (!part.Assembled)
                        throw new Impossible.Service { };
                }
            };
        }
    }
}