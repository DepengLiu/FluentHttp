namespace FluentHttp
{
    using System;
    using System.IO;

    /// <summary>
    /// Represents the event args for response headers received.
    /// </summary>
    public class ResponseHeadersReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// The fluent http response.
        /// </summary>
        private readonly FluentHttpResponse _response;

        /// <summary>
        /// The exception
        /// </summary>
        private readonly Exception _exception;

        /// <summary>
        /// The async state.
        /// </summary>
        private readonly object _asyncState;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseHeadersReceivedEventArgs"/> class.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <param name="asyncState">The async state</param>
        public ResponseHeadersReceivedEventArgs(FluentHttpResponse response, Exception exception, object asyncState)
        {
            _response = response;
            _exception = exception;
            _asyncState = asyncState;
        }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        public Exception Exception
        {
            get { return _exception; }
        }

        /// <summary>
        /// Gets the async state.
        /// </summary>
        public object AsyncState
        {
            get { return _asyncState; }
        }

        /// <summary>
        /// Gets the fluent http response.
        /// </summary>
        public FluentHttpResponse Response
        {
            get { return _response; }
        }

        /// <summary>
        /// Sets the response stream.
        /// </summary>
        /// <param name="stream">The stream to save response into.</param>
        public void SaveResponseIn(Stream stream)
        {
            Response.SaveStream = stream;
        }
    }
}