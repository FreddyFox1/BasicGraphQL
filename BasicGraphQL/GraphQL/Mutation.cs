using BasicGraphQL.GraphQL.Data;
using BasicGraphQL.GraphQL.Extensions;
using HotChocolate;
using System.Threading.Tasks;

namespace BasicGraphQL.GraphQL
{
    public class Mutation
    {
        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSpeakerAsync(
            AddSpeakerInput input,[Service] 
            ApplicationDbContext context)
        {
            var speaker = new Speaker
            {
                Name = input.Name,
                Bio = input.Bio,
                WebSite = input.WebSite
            };

            context.Speakers.Add(speaker);
            await context.SaveChangesAsync();

            return new AddSpeakerPayload(speaker);
        }
    }
}
