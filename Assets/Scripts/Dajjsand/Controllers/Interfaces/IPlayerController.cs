using System;
using Dajjsand.Views.Player;
using UnityEngine;

namespace Dajjsand.Controllers.Interfaces
{
    public interface IPlayerController
    {
        event Action PlayerDead;
        Player Player { get; }
        void Init(Transform spawnPoint);
        void Start();
        void StopPlayer();
    }
}