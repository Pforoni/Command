using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Services
{
    public interface IVideoService
    {
        IEnumerable<Video> GetAllVideos();
        IEnumerable<string> GetVideoData();
        Task<Video> CreateVideo(Video video);
        Task<Video> GetVideoById(string id);

    }
}