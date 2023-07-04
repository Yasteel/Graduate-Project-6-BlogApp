using Microsoft.EntityFrameworkCore;
using StolenBlog.API.Data;
using StolenBlog.API.Interfaces;
using StolenBlog.Models.BlogModels;

namespace StolenBlog.API.Services
{
    public class BlogPostsService : GenericService<BlogPosts>, IBlogPostsService
    {
        private readonly AppDbContext context;

        public BlogPostsService(AppDbContext context)
            : base(context)
        {
            this.context = context;
        }

        //public async Task<List<BlogPosts>> GetAll()
        //{
        //    return await this.context.BlogPosts.ToListAsync();
        //}

        //public async Task<BlogPosts> GetById(int id)
        //{
        //    return await this.context.BlogPosts.SingleOrDefaultAsync(_ => _.PostId == id);
        //}


        //public async void Create(BlogPosts posts)
        //{
        //    await this.context.BlogPosts.AddAsync(posts);
        //    this.context.SaveChanges();
        //}

        //public void Update(BlogPosts post)
        //{
        //    this.context.BlogPosts.Update(post);
        //    this.context.SaveChanges(true);
        //}

        //public void Delete(int id)
        //{
        //    var entity = this.context.BlogPosts.SingleOrDefault(_ => _.PostId == id);
        //    this.context.BlogPosts.Remove(entity!);
        //    this.context.SaveChanges();
        //}
    }
}
