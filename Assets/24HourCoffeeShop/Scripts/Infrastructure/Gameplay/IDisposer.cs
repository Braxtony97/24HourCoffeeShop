public interface IDisposer
{
    bool CanDisposer(GameEnums.GrabItems item);
    void Disposer(IGrabbable grabbable);
}
