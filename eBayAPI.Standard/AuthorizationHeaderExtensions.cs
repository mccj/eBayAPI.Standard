// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace System.Net.Http
{
    /// <summary>
    /// Extensions for HttpRequestMessage
    /// </summary>
    public static class AuthorizationHeaderExtensions
    {
        /// <summary>
        /// Sets a basic authentication header.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        public static void SetBasicAuthentication(this HttpClient client, string userName, string password)
        {
            client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue(userName, password);
        }

        /// <summary>
        /// Sets a basic authentication header for RFC6749 client authentication.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        public static void SetBasicAuthenticationOAuth(this HttpClient client, string userName, string password)
        {
            client.DefaultRequestHeaders.Authorization = new BasicAuthenticationOAuthHeaderValue(userName, password);
        }

        /// <summary>
        /// Sets an authorization header with a given scheme and value.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="scheme">The scheme.</param>
        /// <param name="token">The token.</param>
        public static void SetToken(this HttpClient client, string scheme, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, token);
        }

        /// <summary>
        /// Sets an authorization header with a bearer token.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="token">The token.</param>
        public static void SetBearerToken(this HttpClient client, string token)
        {
            client.SetToken("Bearer", token);
        }

        /// <summary>
        /// Sets a basic authentication header.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        public static void SetBasicAuthentication(this HttpRequestMessage request, string userName, string password)
        {
            request.Headers.Authorization = new BasicAuthenticationHeaderValue(userName, password);
        }

        /// <summary>
        /// Sets a basic authentication header for RFC6749 client authentication.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        public static void SetBasicAuthenticationOAuth(this HttpRequestMessage request, string userName, string password)
        {
            request.Headers.Authorization = new BasicAuthenticationOAuthHeaderValue(userName, password);
        }

        /// <summary>
        /// Sets an authorization header with a given scheme and value.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="scheme">The scheme.</param>
        /// <param name="token">The token.</param>
        public static void SetToken(this HttpRequestMessage request, string scheme, string token)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue(scheme, token);
        }

        /// <summary>
        /// Sets an authorization header with a bearer token.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="token">The token.</param>
        public static void SetBearerToken(this HttpRequestMessage request, string token)
        {
            request.SetToken("Bearer", token);
        }
    }
    /// <summary>
    /// HTTP Basic Authentication authorization header
    /// </summary>
    /// <seealso cref="System.Net.Http.Headers.AuthenticationHeaderValue" />
    public class BasicAuthenticationHeaderValue : AuthenticationHeaderValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAuthenticationHeaderValue"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        public BasicAuthenticationHeaderValue(string userName, string password)
            : base("Basic", EncodeCredential(userName, password))
        { }

        /// <summary>
        /// Encodes the credential.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userName</exception>
        public static string EncodeCredential(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentNullException(nameof(userName));
            if (password == null) password = "";

            Encoding encoding = Encoding.UTF8;
            string credential = String.Format("{0}:{1}", userName, password);

            return Convert.ToBase64String(encoding.GetBytes(credential));
        }
    }
    /// <summary>
    /// HTTP Basic Authentication authorization header for RFC6749 client authentication
    /// </summary>
    /// <seealso cref="System.Net.Http.Headers.AuthenticationHeaderValue" />
    public class BasicAuthenticationOAuthHeaderValue : AuthenticationHeaderValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAuthenticationOAuthHeaderValue"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        public BasicAuthenticationOAuthHeaderValue(string userName, string password)
            : base("Basic", EncodeCredential(userName, password))
        { }

        /// <summary>
        /// Encodes the credential.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userName</exception>
        public static string EncodeCredential(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentNullException(nameof(userName));
            if (password == null) password = "";

            Encoding encoding = Encoding.UTF8;
            string credential = $"{UrlEncode(userName)}:{UrlEncode(password)}";

            return Convert.ToBase64String(encoding.GetBytes(credential));
        }

        private static string UrlEncode(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }

            return Uri.EscapeDataString(value).Replace("%20", "+");
        }
    }

}