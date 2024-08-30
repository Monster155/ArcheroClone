using Dajjsand.Controllers;

namespace Dajjsand.Utils.LevelProgressionStates.Interfaces
{
    public interface ILevelProgressionState
    {
        void SetContext(LevelProgressionController controller);
        void UpdateState();
    }
}