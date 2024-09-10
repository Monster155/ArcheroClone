using System;
using System.Collections.Generic;
using Dajjsand.Views.Enemies;
using Dajjsand.Views.HealthBars;
using UnityEngine;

namespace Dajjsand.Controllers.Interfaces
{
    public interface IEnemiesController
    {
        event Action AllEnemiesDead;
        List<Enemy> Enemies { get; }
        void Init(HealthBarsController hpBarController, Transform[] spawnPoints, Transform container);
        void Start();
    }
}