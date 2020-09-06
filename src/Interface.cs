using System;

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
                    bool assembled = false;
                    layer.StickIn(new Snack.Part.Service
                    {
                        Next = () =>
                        {
                            if (assembled)
                                throw new Impossible.Service { };
                            assembled = true;
                            Plan(desktop).Assemble();
                        }
                    });

                    if (!assembled)
                        throw new Impossible.Service { };
                }
            };
        }
    }
}