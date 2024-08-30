using Dajjsand.Utils.LevelProgressionStates.Interfaces;

namespace Dajjsand.Controllers.Interfaces
{
    public interface ILevelProgressionController
    {
        void Init();
        void ChangeState<T>() where T : ILevelProgressionState;
    }
}