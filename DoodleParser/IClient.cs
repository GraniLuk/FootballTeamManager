using DoodleParser.Model;
using System.Collections.Generic;

namespace DoodleParser
{
    public interface IClient
    {
        List<Participant> GetActivePlayers();
        List<Participant> GetParticipants();
    }
}