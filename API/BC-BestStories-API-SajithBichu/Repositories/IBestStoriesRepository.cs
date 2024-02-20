namespace BC_BestStories_API_SajithBichu.Repositories
{
    public interface IBestStoriesRepository
    {
        Task<List<BestStoriesModel>> GetBestStories(int? noOfStories);
    }
}
