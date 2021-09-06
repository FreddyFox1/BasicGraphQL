using BasicGraphQL.GraphQL.Data;

namespace BasicGraphQL.GraphQL
{
    public class AddSpeakerPayload
    {
        public AddSpeakerPayload(Speaker speaker) => Speaker = speaker;
        public Speaker Speaker { get; }
    }
}
