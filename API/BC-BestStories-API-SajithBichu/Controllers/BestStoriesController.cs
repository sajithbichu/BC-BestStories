using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BC_BestStories_API_SajithBichu.Repositories;
using AutoMapper;

namespace BC_BestStories_API_SajithBichu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestStoriesController : ControllerBase
    {
        private readonly IBestStoriesRepository _BestStoriesRepository;
        private readonly IMapper _mapper;

        public BestStoriesController(IBestStoriesRepository BestStoriesRepository, IMapper _mapper)
        {
            this._BestStoriesRepository = BestStoriesRepository;
            this._mapper = _mapper;
        }

        [HttpGet(Name = "GetBestStories")]
        public async Task<IActionResult> GetBestStories(int? noOfStories)
        {
            try
            {
                var result = await _BestStoriesRepository.GetBestStories(noOfStories);

                return Ok(_mapper.Map<List<BestStoriesDTOModel>>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }



}
