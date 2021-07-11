using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Commander.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    //api/videos
    [Route("api/videos")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        //GET api/videos
        [HttpGet]
        public ActionResult<IEnumerable<Video>> GetAllVideos()
        {
            var videosItems = _videoService.GetAllVideos();

            return Ok(videosItems);
        }


        //GET api/videos/getVideoData
        [HttpGet("getVideoData")]
        public IEnumerable<string> GetVideoData()
        {
            var video = _videoService.GetVideoData();
            return video;
        }

        //POST api/videos
        [HttpPost]
        public async Task CreateVideo(Video video)
        {
            await _videoService.CreateVideo(video);
        
        }

    }
}