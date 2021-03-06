using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SnackAssembler
{
    public class Test
    {
        [Fact]
        public void Test0() =>
            Assert.Throws<Impossible.Service>(() => { Interface.Plan(default).Assemble(); });
        [Fact]
        public void Test1() =>
            Interface.Plan(Desktop.Interface.PickUpAll()).Assemble();
        [Fact]
        public void Test2() =>
            Assert.Throws<Impossible.Service>(() => { Interface.Plan(Desktop.Interface.PickUpAll(new Layer.NotDelivered())).Assemble(); });
        [Fact]
        public void Test3() =>
            Assert.Throws<Impossible.Service>(() => { Interface.Plan(Desktop.Interface.PickUpAll(new Layer.ManyDelivered())).Assemble(); });
        [Fact]
        public void Test4() =>
           Interface.Plan(Desktop.Interface.PickUpAll(new Layer.OneDelivered())).Assemble();
        [Fact]
        public void Test5() =>
            Assert.False(Desktop.Interface.PickUpAll().Layers.Any());
        [Fact]
        public void Test6() =>
            Assert.False(Desktop.Interface.PickUpAll(default).Layers.Any());
        [Fact]
        public void Test7() =>
            Assert.False(Desktop.Interface.PickUpAll(default, default).Layers.Any());
        [Fact]
        public void Test8() =>
            Assert.False(Desktop.Interface.PickUpAll(new Layer.OneDelivered { }).Layers.Skip(1).Any());
        [Fact]
        public void Test9() =>
            Assert.False(Desktop.Interface.PickUpAll(new Layer.OneDelivered { }, default, new Layer.OneDelivered { }).Layers.Skip(2).Any());
        [Fact]
        public void Test10() =>
            Assert.False(Desktop.Interface.PickUpAll(new Layer.OneDelivered { }, default, new Layer.OneDelivered { }).Layers.Skip(2).Any());

        [Fact]
        public void TestXEgg()
        {
            static IEnumerable<string> xegg()
            {
                var messages = new List<string>();
                Interface.Plan(
                    Desktop.Interface.PickUpAll(
                        new Layer.XEgg.Bread(messages),
                        new Layer.XEgg.Egg(messages),
                        new Layer.XEgg.Cheese(messages)
                    )
                )
                .Assemble();
                return messages;
            }

            Assert.Equal("Bread0|Egg|Cheese|Bread1", string.Join("|", xegg()));
        }

        [Fact]
        public void TestBigMac()
        {
            static IEnumerable<string> bigmac()
            {
                var messages = new List<string>();
                Interface.Plan(
                    Desktop.Interface.PickUpAll(
                        new Layer.BigMac.SesameBread(messages),
                        new Layer.BigMac.Hambuger(messages),
                        new Layer.BigMac.Hambuger(messages),
                        new Layer.BigMac.Cheese(messages),
                        new Layer.BigMac.Lettuce(messages),
                        new Layer.BigMac.SpecialSauce(messages),
                        new Layer.BigMac.Onion(messages),
                        new Layer.BigMac.Pickles(messages)
                    )
                )
                .Assemble();
                return messages;
            }

            Assert.Equal("SesameBread0|Hambuger|Hambuger|Cheese|Lettuce|SpecialSauce|Onion|Pickles|Lettuce|SesameBread1", string.Join("|", bigmac()));
        }

        [Fact]
        public void TestMultiLayerExceptionFilters()
        {
            static IEnumerable<string> withoutNext()
            {
                var messages = new List<string>();
                Interface.Plan(
                    Desktop.Interface.PickUpAll(
                        new Layer.MultiLayerExceptionFilter.Silent(messages),
                        new Layer.MultiLayerExceptionFilter.Authentication(messages),
                        new Layer.MultiLayerExceptionFilter.Cryptography(messages),
                        new Layer.MultiLayerExceptionFilter.WithoutNextThrowCriptography()
                    )
                )
                .Assemble();
                return messages;
            }

            static IEnumerable<string> withNext()
            {
                var messages = new List<string>();
                Interface.Plan(
                    Desktop.Interface.PickUpAll(
                        new Layer.MultiLayerExceptionFilter.Silent(messages),
                        new Layer.MultiLayerExceptionFilter.Authentication(messages),
                        new Layer.MultiLayerExceptionFilter.Cryptography(messages),
                        new Layer.MultiLayerExceptionFilter.WithNextThrowCriptography()
                    )
                )
                .Assemble();
                return messages;
            }

            static IEnumerable<string> authenticate()
            {
                var messages = new List<string>();
                Interface.Plan(
                    Desktop.Interface.PickUpAll(
                        new Layer.MultiLayerExceptionFilter.Silent(messages),
                        new Layer.MultiLayerExceptionFilter.Authentication(messages),
                        new Layer.MultiLayerExceptionFilter.Cryptography(messages),
                        new Layer.MultiLayerExceptionFilter.ThrowAutenthicate()
                    )
                )
                .Assemble();
                return messages;
            }

            Assert.Equal("Error occurred during a cryptographic operation.|Silent", string.Join("|", withoutNext()));
            Assert.Equal("Error occurred during a cryptographic operation.|Silent", string.Join("|", withNext()));
            Assert.Equal("CustomMessageAuthenticateException|Silent", string.Join("|", authenticate()));
        }
    }
}