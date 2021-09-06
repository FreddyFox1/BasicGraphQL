using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BasicGraphQL.GraphQL.Extensions
{
    /// <summary>
    /// The UseDbContext will create a new middleware that 
    /// handles scoping for a field. The create part will 
    /// rent from the pool a DBContext, the dispose part 
    /// will return it after the middleware is finished. 
    /// All of this is handled transparently through 
    /// the new IDbContextFactory<T> introduced with .NET 5.
    /// </summary>
    public static class ObjectFieldDescriptorExtensions
    {
        public static IObjectFieldDescriptor UseDbContext<TDbContext>(
            this IObjectFieldDescriptor descriptor)
            where TDbContext : DbContext
        {
            return descriptor.UseScopedService<TDbContext>(
                create: s => s.GetRequiredService<IDbContextFactory<TDbContext>>()
                              .CreateDbContext(),
                disposeAsync: (s, c) => c.DisposeAsync());
        }
    }
}
