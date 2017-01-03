using System;
using ActorModel.Actors;
using ActorModel.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var account = new AccountActor();
            var output = new OutputActor();

            account.Send(new Deposit { Amount = 50 });
            account.Send(new QueryBalance { Receiver = output });

            account.Completion.Wait();
            output.Completion.Wait();

            Console.WriteLine("Done!");
            //Console.ReadLine();
        }
    }
}
