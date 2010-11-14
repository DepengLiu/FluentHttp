namespace FluentHttp
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Fluent Http Wrapper
    /// </summary>
    public partial class FluentHttpRequest
    {
        /// <summary>
        /// Occurs just before executing the web request.
        /// </summary>
        public event EventHandler<ExecutingEventArgs> Executing;

        public FluentHttpRequest OnExecuting(EventHandler<ExecutingEventArgs> eventHandler)
        {
            return OnExecuting(eventHandler, false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public FluentHttpRequest OnExecuting(EventHandler<ExecutingEventArgs> eventHandler, bool remove)
        {
            if (eventHandler != null)
            {
                if (remove)
                    Executing -= eventHandler;
                else
                    Executing += eventHandler;
            }

            return this;
        }
    }
}