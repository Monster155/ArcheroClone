using System;
using Dajjsand.Views.HealthBars;
using Dajjsand.Views.Player;
using UnityEngine;

namespace Dajjsand.Controllers.Interfaces
{
    public interface IPlayerController
    {
        event Action PlayerDead;
        Player Player { get; }
        void Init(HealthBarsController hpBarController, Transform spawnPoint);
        void Start();
        void StopPlayer();
    }
}