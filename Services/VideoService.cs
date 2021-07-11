using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Models;

namespace Commander.Services
{
    public class VideoService : IVideoService
    {
         private readonly IMongoRepository<Video> _repository;
        private readonly IMapper _mapper;

        public VideoService(IMongoRepository<Video> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task CreateVideo(Video video)
        {
           await _repository.InsertOneAsync(video);
        }

        public IEnumerable<Video> GetAllVideos()
        {
            var videosItems = _repository.AsQueryable();
            return videosItems;
        }

        public IEnumerable<string> GetVideoData()
        {
            var video = _repository.FilterBy(
                filter => filter.VideoName != "test",
                projection => projection.VideoName
            );

            return video;
        }
    }
}