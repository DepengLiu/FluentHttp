
namespace FluentHttp
{
    using System;
    using System.Linq;

    /// <summary>
    /// Base class for OAuth2 Authenticators.
    /// </summary>
    public abstract class OAuth2Authenticator : IFluentAuthenticator
    {
        /// <summary>
        /// The oauth_token
        /// </summary>
        private readonly string _accessToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuth2Authenticator"/> class.
        /// </summary>
        /// <param name="accessToken">
        /// The access token.
        /// </param>
        public OAuth2Authenticator(string accessToken)
        {
            _accessToken = accessToken;
        }

        /// <summary>
        /// Gets the OAuth2 token.
        /// </summary>
        public string OAuthToken
        {
            get { return _accessToken; }
        }

        #region Implementation of IFluentAuthenticator

        /// <summary>
        /// Authenticate the fluent http request using OAuth2.
        /// </summary>
        /// <param name="fluentHttpRequest">
        /// The fluent http request.
        /// </param>
        public abstract void Authenticate(FluentHttpRequest fluentHttpRequest);

        #endregion
    }

    /// <summary>
    /// The OAuth 2 authenticator using the authorization request header field.
    /// </summary>
    /// <remarks>
    /// Based on http://tools.ietf.org/html/draft-ietf-oauth-v2-10#section-5.1.1
    /// </remarks>
    public class OAuth2AuthorizationRequestHeaderAuthenticator : OAuth2Authenticator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuth2AuthorizationRequestHeaderAuthenticator"/> class.
        /// </summary>
        /// <param name="accessToken">
        /// The access token.
        /// </param>
        public OAuth2AuthorizationRequestHeaderAuthenticator(string accessToken)
            : base(accessToken)
        {
        }

        #region Overrides of OAuth2Authenticator

        /// <summary>
        /// Authenticate the fluent http request using OAuth2 request header.
        /// </summary>
        /// <param name="fluentHttpRequest">
        /// The fluent http request.
        /// </param>
        public override void Authenticate(FluentHttpRequest fluentHttpRequest)
        {
#if AGGRESSIVE_CHECK
            if (fluentHttpRequest.GetHeaders().Any(header => header.Name.Equals("Authorization")))
                throw new Exception("fluentHttpRequest already contains 'Authorization' header");
#endif
            fluentHttpRequest.Headers(headers =>
                                      headers
                                          .Add("Authorization", "OAuth " + OAuthToken));
        }

        #endregion
    }
}