﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.Behavioral
{
    internal class StateDesignPattern
    {
        public class Context
        {
            private State _state = null;

            public Context(State state)
            {
                this.TransitionTo(state);
            }

            public void TransitionTo(State state)
            {
                Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
                this._state = state;
                this._state.SetContext(this);
            }

            public void Request1()
            {
                this._state.Handle1();
            }

            public void Request2()
            {
                this._state.Handle2();
            }
        }

        public abstract class State
        {
            protected Context _context;

            public void SetContext(Context context)
            {
                this._context = context;
            }

            public abstract void Handle1();

            public abstract void Handle2();
        }

        public class ConcreteStateA : State
        {
            public override void Handle1()
            {
                Console.WriteLine("ConcreteStateA handles request1.");
                Console.WriteLine("ConcreteStateA wants to change the state of the context.");
                this._context.TransitionTo(new ConcreteStateB());
            }

            public override void Handle2()
            {
                Console.WriteLine("ConcreteStateA handles request2.");
            }
        }

        public class ConcreteStateB : State
        {
            public override void Handle1()
            {
                Console.Write("ConcreteStateB handles request1.");
            }

            public override void Handle2()
            {
                Console.WriteLine("ConcreteStateB handles request2.");
                Console.WriteLine("ConcreteStateB wants to change the state of the context.");
                this._context.TransitionTo(new ConcreteStateA());
            }
        }

    }
}
