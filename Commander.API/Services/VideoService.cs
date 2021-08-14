using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Commander.API.Data;
using Commander.API.Models;

namespace Commander.API.Services
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

        public async Task<Video> CreateVideo(Video video)
        {
            await _repository.InsertOneAsync(video);
            return video;
        }

        public IEnumerable<Video> GetAllVideos()
        {
            var videosItems = _repository.AsQueryable();
            return videosItems;
        }

        public async Task<Video> GetVideoById(string id)
        {
            var video = await _repository.FindByIdAsync(id);
            return video;
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