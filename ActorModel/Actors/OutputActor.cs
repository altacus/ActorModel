using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActorModel.Messages;

namespace ActorModel.Actors
{
    public class OutputActor : Actor
    {
        public override void Handle(Message message)
        {
            var balance = message as Balance;
            if (balance != null)
                Console.WriteLine("Balance is {0}", balance.Amount);    
        }
    }
}
