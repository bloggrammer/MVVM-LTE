using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM.LTE.SimpleEvents
{
    public class CustomEvent
    {
        public delegate void DoAction();

        public event DoAction ActionCompleted;

        public event DoAction ActionFailed;

        protected virtual void OnProcessCompleted()
        {
            ActionCompleted?.Invoke();
        }

        protected virtual void OnActionFailed() { }
        public void StartAction(Action action)
        {
            OnProcessCompleted();
            if (action != null)
            {
                action();
            }
        }
    }
}
