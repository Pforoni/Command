using System;
using System.Threading.Tasks;
using Commander.API.Controllers;
using Commander.API.Models;
using Commander.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Commander.UnitTests
{
    public class VideoControllerTest
    {
        //Declarando os mocks para serem utilizados em todos os testes
        private readonly Mock<IVideoService> serviceStub = new();

        //Se tivesse a biblioteca Logger no construtor da Controller
        private readonly Mock<ILogger<VideosController>> loggerStub = new();
        [Fact]
        public async Task GetVideobyId_WithUnexistingItem_ReturnsNotFound()
        {           
            //Arrange
            //var serviceStub = new Mock<IVideoService>();
            serviceStub.Setup(repo => repo.GetVideoById(It.IsAny<string>()))
                .ReturnsAsync((Video)null);

            //Se tivesse a biblioteca Logger no construtor da Controller
            //var loggerStub = new Mock<ILogger<VideosController>>();

            var controller = new VideosController(serviceStub.Object);
            //Act
            var result = await controller.GetVideobyId("1243");

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
            
            //A mesma coisa só que utilizando a biblioteca FluentAssertions
            //Assert
            result.Result.Should().BeOfType<NotFoundResult>();

        }

        [Fact]
        public async Task GetVideobyId_WithExistingItem_ReturnsExpectedItem()
        {  
            //Arrange
            var expectedVideo = CreateRandomVideo();

            serviceStub.Setup(repo => repo.GetVideoById(It.IsAny<string>()))
                .ReturnsAsync(expectedVideo);
            
            var controller = new VideosController(serviceStub.Object);

            //Act
            var result = await controller.GetVideobyId("1243");

            //Assert
            Assert.IsType<Video>(result.Value);
            var returnVideo = (result as ActionResult<Video>).Value;
            Assert.Equal(expectedVideo.Id, returnVideo.Id);
            Assert.Equal(expectedVideo.Assunto, returnVideo.Assunto);

            //A mesma coisa só que utilizando a biblioteca FluentAssertions
            //Assert
            result.Value.Should().BeEquivalentTo(expectedVideo);
                //OR verificando propriedade por propriedade
            result.Value.Should().BeEquivalentTo(
                expectedVideo,
                options => options.ComparingByMembers<Video>()
            );


        } 

        //Metodo para gerar um objeto Video
        private Video CreateRandomVideo()
        {
            return new(){
                Id = MongoDB.Bson.ObjectId.GenerateNewId(),
                Assunto = Guid.NewGuid().ToString(),
                URL = Guid.NewGuid().ToString(),
                VideoName = Guid.NewGuid().ToString()
            };
        }
    }
}