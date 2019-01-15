using System;
using System.Collections.Generic;
using System.Text;

namespace music_player_android.Interfaces
{
    public interface IPlayer
    {

        void StartPlayer(String filepath);

        void PausePlayer();

        void StopPlayer();

        void ReleasePlayer();
    }
}
