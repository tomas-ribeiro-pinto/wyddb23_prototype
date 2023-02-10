using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BlazorWYDDB23.Server.Interfaces;
using BlazorWYDDB23.Server.Data;
using BlazorWYDDB23.Shared.Models;

namespace BlazorWYDDB23.Server.Services
{
	public class PostManager : IPost
	{
        readonly ApplicationDbContext _dbContext;
        public PostManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //To Get all user details
        public List<Post> GetPostDetails()
        {
            try
            {
                return _dbContext.Posts.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new user record
        public void AddPost(Post post)
        {
            try
            {
                _dbContext.Posts.Add(post);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar user
        public void UpdatePostDetails(Post post)
        {
            try
            {
                _dbContext.Entry(post).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular user
        public Post GetPostData(int id)
        {
            try
            {
                Post? post = _dbContext.Posts.Find(id);
                if (post != null)
                {
                    return post;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular user
        public void DeletePost(int id)
        {
            try
            {
                Post? post = _dbContext.Posts.Find(id);
                if (post != null)
                {
                    _dbContext.Posts.Remove(post);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

