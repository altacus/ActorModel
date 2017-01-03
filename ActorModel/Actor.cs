using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ActorModel
{
    public abstract class Actor
    {
        private readonly ActionBlock<Message> _action;

        public Task Completion
        {
            get
            {
                _action.Complete();
                return _action.Completion;
            }
        }

        public virtual void Handle(Message mess)
        {
        }

        protected Actor()
        {
            _action = new ActionBlock<Message>(message =>
            {
                var self = this;
                var mess = message;
                self.Handle(mess);
            });
        }

        public void Send(Message message)
        {
            _action.Post(message);
        }
    }
}
