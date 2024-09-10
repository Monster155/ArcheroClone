using Dajjsand.Views.CollidingHandlers;
using Dajjsand.Views.HealthBars;
using Dajjsand.Views.Screens;
using UnityEngine;

namespace Dajjsand.Utils
{
    public class GameplayObjectsContainer : MonoBehaviour
    {
        [field: SerializeField] public Canvas UICanvas { get; private set; }
        [field: SerializeField] public LoadingScreen LoadingScreen { get; private set; }
        [field: SerializeField] public GameFinishScreen GameLoseScreen { get; private set; }
        [field: SerializeField] public GameFinishScreen GameWinScreen { get; private set; }
        [field: Space]
        [field: SerializeField] public Transform PlayerSpawnPoint { get; private set; }
        [field: Space]
        [field: SerializeField] public Transform BulletsContainer { get; private set; }
        [field: Space]
        [field: SerializeField] public Transform[] EnemiesSpawnPoints { get; private set; }
        [field: SerializeField] public Transform EnemiesContainer { get; private set; }
        [field: Space]
        [field: SerializeField] public EscapeRoomDoorHandler EscapeRoomDoorHandler { get; private set; }
        [field: Space]
        [field: SerializeField] public HealthBarsController HealthBarsController { get; private set; }
    }
}