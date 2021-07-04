using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    //api/videos
    [Route("api/videos")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IRepository<Video> _repository;
        private readonly IMapper _mapper;

        public VideosController(IRepository<Video> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        //GET api/videos
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllVideos()
        {
            var videosItems = _repository.GetAll();

            return Ok(videosItems);
        }

    }
}