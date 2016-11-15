﻿using Marvel.Api.Filters;
using Marvel.Api.Results;
using RestSharp;

namespace Marvel.Api
{
    public partial class MarvelRestClient
    {
        private const string CharactersUrlSegment = "/public/characters";

        /// <summary>
        /// Fetches lists of comic characters with optional filters.
        /// </summary>
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual CharacterResult GetCharacters(CharacterRequestFilter filter = default(CharacterRequestFilter))
        {
            var request = new RestRequest(CharactersUrlSegment, Method.GET);

  

            // Parse filter
            //
            ParseCharacterFilter(request, filter);

            return Execute<CharacterResult>(request);
        }

        public virtual CharacterResult GetCharacters(int offeset)
        {
            var request = new RestRequest(CharactersUrlSegment, Method.GET);
            request.AddParameter("offset", offeset);
            request.AddParameter("limit", 100);
            ParseCharacterFilter(request, null);

            return Execute<CharacterResult>(request);
        }
    

    /// <summary>
    /// This method fetches a single character resource.
    /// It is the canonical URI for any character resource provided by the API.
    /// </summary>
    /// <param name="characterId">
    /// Character unique identifier
    /// </param>
    public virtual CharacterResult GetCharacter(string characterId)
    {
        // Build request url
        //
        string requestUrl =
            string.Format("{0}/{1}", CharactersUrlSegment, characterId);

        var request = new RestRequest(requestUrl, Method.GET);

        return Execute<CharacterResult>(request);
    }

    /// <summary>
    /// Fetches lists of comics containing a specific character,
    /// with optional filters.
    /// </summary>
    /// <param name="characterId">
    /// Character unique identifier
    /// </param>
    /// <param name="filter">
    /// Search query filter data
    /// </param>
    public virtual ComicResult GetCharacterComics(string characterId, ComicRequestFilter filter = default(ComicRequestFilter))
    {
        // Build request url
        //
        string requestUrl =
            string.Format("{0}/{1}/comics", CharactersUrlSegment, characterId);

        var request = new RestRequest(requestUrl, Method.GET);

        // Parse filter
        //
        ParseComicFilter(request, filter);

        return Execute<ComicResult>(request);
    }

    /// <summary>
    /// Fetches lists of events in which a specific character appears,
    /// with optional filters.
    /// </summary>
    /// <param name="characterId">
    /// Character unique identifier
    /// </param>
    /// <param name="filter">
    /// Search query filter data
    /// </param>
    public virtual EventResult GetCharacterEvents(string characterId, EventRequestFilter filter = default(EventRequestFilter))
    {
        // Build request url
        //
        string requestUrl =
            string.Format("{0}/{1}/events", CharactersUrlSegment, characterId);

        var request = new RestRequest(requestUrl, Method.GET);

        // Parse filter
        //
        ParseEventFilter(request, filter);

        return Execute<EventResult>(request);
    }

    /// <summary>
    /// Fetches lists of comic series in which a specific character appears,
    /// with optional filters.
    /// </summary>
    /// <param name="characterId">
    /// Character unique identifier
    /// </param>
    /// <param name="filter">
    /// Search query filter data
    /// </param>
    public virtual SeriesResult GetCharacterSeries(string characterId, SeriesRequestFilter filter = default(SeriesRequestFilter))
    {
        // Build request url
        //
        string requestUrl =
            string.Format("{0}/{1}/series", CharactersUrlSegment, characterId);

        var request = new RestRequest(requestUrl, Method.GET);

        // Parse filter
        //
        ParseSeriesFilter(request, filter);

        return Execute<SeriesResult>(request);
    }

    /// <summary>
    /// Fetches lists of comic stories featuring a specific character with optional filters.
    /// </summary>
    /// <param name="characterId">
    /// Character unique identifier
    /// </param>
    /// <param name="filter">
    /// Search query filter data
    /// </param>
    public virtual StoryResult GetCharacterStories(string characterId, StoryRequestFilter filter = default(StoryRequestFilter))
    {
        // Build request url
        //
        string requestUrl =
            string.Format("{0}/{1}/stories", CharactersUrlSegment, characterId);

        var request = new RestRequest(requestUrl, Method.GET);

        // Parse filter
        //
        ParseStoryFilter(request, filter);

        return Execute<StoryResult>(request);
    }
}
}