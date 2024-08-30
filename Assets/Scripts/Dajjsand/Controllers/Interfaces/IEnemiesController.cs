using System;
using System.Collections.Generic;
using Dajjsand.Views.Enemies;
using UnityEngine;

namespace Dajjsand.Controllers.Interfaces
{
    public interface IEnemiesController
    {
        event Action AllEnemiesDead;
        List<Enemy> Enemies { get; }
        void Init(Transform[] spawnPoints, Transform container);
        void Start();
    }
}