﻿using Marvel.Api.Filters;
using Marvel.Api.Results;
using RestSharp;

namespace Marvel.Api
{
    public partial class MarvelRestClient
    {
        private const string EventsUrlSegment = "/public/events";

        /// <summary>
        /// Fetches lists of events with optional filters.
        /// </summary>
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual EventResult GetEvents(EventRequestFilter filter = default(EventRequestFilter))
        {
            var request = new RestRequest(EventsUrlSegment, Method.GET);

            // Parse filter
            //
            ParseEventFilter(request, filter);

            return Execute<EventResult>(request);
        }

        /// <summary>
        /// This method fetches a single event resource. 
        /// It is the canonical URI for any event resource provided by the API.
        /// </summary>
        /// <param name="eventId">
        /// Event unique identifier
        /// </param>        
        public virtual EventResult GetEvent(string eventId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}", EventsUrlSegment, eventId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<EventResult>(request);
        }

        /// <summary>
        /// Fetches lists of characters which appear in a specific event, 
        /// with optional filters.
        /// </summary>
        /// <param name="eventId">
        /// Event unique identifier
        /// </param>       
        /// <param name="filter">
        /// Search query filter data
        /// </param> 
        public virtual CharacterResult GetEventCharacters(string eventId, CharacterRequestFilter filter = default(CharacterRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/characters", EventsUrlSegment, eventId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseCharacterFilter(request, filter);

            return Execute<CharacterResult>(request);
        }

        /// <summary>
        /// Fetches lists of comics which take place during a specific event, 
        /// with optional filters.
        /// </summary>
        /// <param name="eventId">
        /// Event unique identifier
        /// </param>        
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual ComicResult GetEventComics(string eventId, ComicRequestFilter filter = default(ComicRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/comics", EventsUrlSegment, eventId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseComicFilter(request, filter);

            return Execute<ComicResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic creators whose work appears in a specific event, 
        /// with optional filters.
        /// </summary>
        /// <param name="eventId">
        /// Event unique identifier
        /// </param>       
        /// <param name="filter">
        /// Search query filter data
        /// </param> 
        public virtual CreatorResult GetEventCreators(string eventId, CreatorRequestFilter filter = default(CreatorRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/creators", EventsUrlSegment, eventId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseCreatorFilter(request, filter);

            return Execute<CreatorResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic series in which a specific event takes place, 
        /// with optional filters.
        /// </summary>
        /// <param name="eventId">
        /// Event unique identifier
        /// </param>    
        /// <param name="filter">
        /// Search query filter data
        /// </param>    
        public virtual SeriesResult GetEventSeries(string eventId, SeriesRequestFilter filter = default(SeriesRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/series", EventsUrlSegment, eventId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseSeriesFilter(request, filter);

            return Execute<SeriesResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic stories from a specific event, 
        /// with optional filters.
        /// </summary>
        /// <param name="eventId">
        /// Event unique identifier
        /// </param>      
        /// <param name="filter">
        /// Search query filter data
        /// </param>  
        public virtual StoryResult GetEventStories(string eventId, StoryRequestFilter filter = default(StoryRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/stories", EventsUrlSegment, eventId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseStoryFilter(request, filter);

            return Execute<StoryResult>(request);
        }
    }
}
