﻿using Marvel.Api.Filters;
using Marvel.Api.Results;
using RestSharp;

namespace Marvel.Api
{
    public partial class MarvelRestClient
    {
        private const string ComicsUrlSegment = "/public/comics";

        /// <summary>
        /// Fetches lists of comics with optional filters.
        /// </summary>      
        /// <param name="filter">
        /// Search query filter data
        /// </param>  
        public virtual ComicResult GetComics(ComicRequestFilter filter = default(ComicRequestFilter))
        {            
            var request = new RestRequest(ComicsUrlSegment, Method.GET);

            // Parse filter
            //
            ParseComicFilter(request, filter);

            return Execute<ComicResult>(request);
        }

        /// <summary>
        /// This method fetches a single comic resource. 
        /// It is the canonical URI for any comic resource provided by the API.
        /// </summary>
        /// <param name="comicId">
        /// Comic unique identifier
        /// </param>        
        public virtual ComicResult GetComic(string comicId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}", ComicsUrlSegment, comicId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<ComicResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic creators whose work appears in a specific comic, 
        /// with optional filters.
        /// </summary>
        /// <param name="comicId">
        /// Comic unique identifier
        /// </param>
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual CreatorResult GetComicCreators(string comicId, CreatorRequestFilter filter = default(CreatorRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/creators", ComicsUrlSegment, comicId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseCreatorFilter(request, filter);

            return Execute<CreatorResult>(request);
        }

        /// <summary>
        /// Fetches lists of characters which appear in a specific comic with optional filters.
        /// </summary>
        /// <param name="comicId">
        /// Comic unique identifier
        /// </param>
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual CharacterResult GetComicCharacters(string comicId, CharacterRequestFilter filter = default(CharacterRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/characters", ComicsUrlSegment, comicId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseCharacterFilter(request, filter);

            return Execute<CharacterResult>(request);
        }

        /// <summary>
        /// Fetches lists of events in which a specific comic appears, 
        /// with optional filters.
        /// </summary>
        /// <param name="comicId">
        /// Comic unique identifier
        /// </param>
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual EventResult GetComicEvents(string comicId, EventRequestFilter filter = default(EventRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/events", ComicsUrlSegment, comicId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseEventFilter(request, filter);

            return Execute<EventResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic stories in a specific comic issue, with optional filters.
        /// </summary>
        /// <param name="comicId">
        /// Comic unique identifier
        /// </param>
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual StoryResult GetComicStories(string comicId, StoryRequestFilter filter = default(StoryRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/stories", ComicsUrlSegment, comicId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseStoryFilter(request, filter);

            return Execute<StoryResult>(request);
        }
    }
}
