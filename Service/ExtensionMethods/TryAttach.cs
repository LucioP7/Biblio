using Microsoft.EntityFrameworkCore;

namespace Service.ExtensionMethods
{
    public static class DbContextExtensions
    {
        public static void TryAttach<T>(this DbContext context, T entity) where T : class
        {
            if (entity == null) return;
            var entry = context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                context.Attach(entity);
            }
        }
    }
}
