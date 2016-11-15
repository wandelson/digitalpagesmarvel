﻿using System;
using System.Text;
using RestSharp;
using RestSharp.Extensions;

namespace Marvel.Api
{
    public abstract partial class MarvelClient
    {
        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
        /// <param name="request">The RestRequest to execute (will use client credentials)</param>
        /// <param name="callback">The callback function to execute when the async request completes</param>
        public virtual void ExecuteAsync<T>(IRestRequest request, Action<T> callback) where T : new()
        {
            request.OnBeforeDeserialization = (resp) =>
            {
                // for individual resources when there's an error to make
                // sure that RestException props are populated
                if (((int)resp.StatusCode) >= 400)
                {
                    // have to read the bytes so .Content doesn't get populated
                    const string restException = "{{ \"RestException\" : {0} }}";
                    var content = resp.RawBytes.AsString(); //get the response content
                    var newJson = string.Format(restException, content);

                    resp.Content = null;
                    resp.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString());
                }
            };

            request.DateFormat = "ddd, dd MMM yyyy HH:mm:ss '+0000'";

            Client.ExecuteAsync<T>(request, (response) => callback(response.Data));
        }

        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <param name="request">The RestRequest to execute (will use client credentials)</param>
        /// <param name="callback">The callback function to execute when the async request completes</param>
        public virtual void ExecuteAsync(IRestRequest request, Action<IRestResponse> callback)
        {
            Client.ExecuteAsync(request, callback);
        }
    }
}
