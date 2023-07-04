namespace StolenBlog.API.Services
{
    using Microsoft.EntityFrameworkCore;
    using StolenBlog.API.Data;
    using StolenBlog.API.Interfaces;

    public class GenericService<T> : IGenericService<T>
        where T : class
    {
        private readonly AppDbContext context;

        public GenericService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<T> Get(int id)
        {
            return await this.context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await this.context.Set<T>().ToListAsync();
        }

        public async void Create(T model)
        {
            await this.context.Set<T>().AddAsync(model);
            this.context.SaveChanges();
        }
        
        public void Update(int id, T model)
        {
            this.context.Set<T>().Attach(model);
            this.context.Entry(model).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = this.context.Set<T>().Find(id);
            this.context.Set<T>().Remove(entity);
            this.context.SaveChanges();
        }
    }
}
