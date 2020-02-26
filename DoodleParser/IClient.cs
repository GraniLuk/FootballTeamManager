using DoodleApi.Model;
using System;
using System.Collections.Generic;

namespace DoodleApi
{
    public interface IApi
    {
        List<Participant> GetActivePlayersAt(DateTime date);
    }
}