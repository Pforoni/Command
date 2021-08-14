using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Commander.API.Data;
using Commander.API.Dtos;
using Commander.API.Models;
using Commander.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.API.Controllers
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

        //GET api/videos/{id}
        [HttpGet("{id}", Name = "GetVideobyId")]
        public async Task<ActionResult<Video>> GetVideobyId(string Id)
        {
            var video = await _videoService.GetVideoById(Id);
            return video;
        }

        //POST api/videos
        [HttpPost]
        public async Task<ActionResult<Video>> CreateVideo(Video video)
        {
            var videoAdd = await _videoService.CreateVideo(video);
            return CreatedAtRoute(nameof(GetVideobyId), new { Id = videoAdd.Id }, videoAdd);
        }

    }
}