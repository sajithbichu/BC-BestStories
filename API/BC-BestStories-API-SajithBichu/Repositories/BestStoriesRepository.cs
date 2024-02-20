namespace BC_BestStories_API_SajithBichu.Repositories
{
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Caching.Memory;

    public class BestStoriesRepository : IBestStoriesRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private string CacheKey = "by";
        private IConfiguration _configuration;

        public BestStoriesRepository(HttpClient HttpClient, IConfiguration Configuration, IMemoryCache IMemoryCache)
        {
            this._httpClient = HttpClient;
            this._configuration = Configuration;
            this._memoryCache = IMemoryCache;
        }

        public async Task<List<BestStoriesModel>>? GetBestStories(int? noOfStories)
        {
            try
            {
                List<BestStoriesModel> _BestStoriesList = new List<BestStoriesModel>();
                BestStoriesModel _BestStoriesItem;

                if (!_memoryCache.TryGetValue(CacheKey, out _BestStoriesList))
                {
                    _BestStoriesList = new List<BestStoriesModel>();
                    var responseIDs = await _httpClient.GetFromJsonAsync<int[]>(_configuration.GetSection("AppSettings:URLBestStories").Value);
                    if (responseIDs != null)
                    {
                        string URLBestStoriesById = _configuration.GetSection("AppSettings:URLBestStoriesById").Value;
                        foreach (var item in responseIDs)
                        {
                            _BestStoriesItem = new BestStoriesModel();
                            _BestStoriesItem = await _httpClient.GetFromJsonAsync<BestStoriesModel>(URLBestStoriesById.Replace("replace", item.ToString()));
                            _BestStoriesList.Add(_BestStoriesItem);
                        }
                        _BestStoriesList.OrderByDescending(i => i.score);
                        _memoryCache.Set(CacheKey, _BestStoriesList, TimeSpan.FromHours(1));
                    }
                }

                if (noOfStories != null)
                    return _BestStoriesList.Take(Convert.ToInt32(noOfStories)).ToList();
                else
                    return _BestStoriesList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
