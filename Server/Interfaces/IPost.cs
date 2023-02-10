using System;
using BlazorWYDDB23.Shared.Models;

namespace BlazorWYDDB23.Server.Interfaces
{
	public interface IPost
	{
        public List<Post> GetPostDetails();
        public void AddPost(Post post);
        public void UpdatePostDetails(Post post);
        public Post GetPostData(int id);
        public void DeletePost(int id);
    }
}

