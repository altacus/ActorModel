using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActorModel.Messages;

namespace ActorModel.Actors
{
    public class AccountActor : Actor
    {
        private decimal _balance;

        public override void Handle(Message message)
        {
            var deposit = message as Deposit;
            if (deposit != null)
                _balance += deposit.Amount;
            else
            {
                var queryBalance = message as QueryBalance;
                if (queryBalance != null)
                    queryBalance.Receiver.Send(new Balance { Amount = _balance });
            }
        }
    }
}
