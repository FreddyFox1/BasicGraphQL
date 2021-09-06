using BasicGraphQL.GraphQL.Data;
using BasicGraphQL.GraphQL.Extensions;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicGraphQL.GraphQL
{
    public class Query
    {
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) =>
            context.Speakers.ToListAsync();
    }
}
