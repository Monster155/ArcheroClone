namespace Dajjsand.Services.InputServices.Interfaces
{
    public interface IInputService
    {
        float Horizontal { get; }
        float Vertical { get; }
        void Init();
    }
}