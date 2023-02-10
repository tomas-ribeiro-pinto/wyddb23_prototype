using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorWYDDB23.Server.Data;
using BlazorWYDDB23.Server.Interfaces;
using BlazorWYDDB23.Shared.Models;

namespace BlazorWYDDB23.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPost _IPost;
        public PostController(IPost iPost)
        {
            _IPost = iPost;
        }
        [HttpGet]
        public async Task<List<Post>> Get()
        {
            return await Task.FromResult(_IPost.GetPostDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Post post = _IPost.GetPostData(id);
            if (post != null)
            {
                return Ok(post);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(Post post)
        {
            _IPost.AddPost(post);
        }
        [HttpPut]
        public void Put(Post post)
        {
            _IPost.UpdatePostDetails(post);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IPost.DeletePost(id);
            return Ok();
        }
    }
}

