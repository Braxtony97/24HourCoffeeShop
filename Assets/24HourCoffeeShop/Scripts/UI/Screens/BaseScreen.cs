using UnityEngine;

public abstract class BaseScreen : MonoBehaviour
{
    [Header("\nScreen type")]
    public GameEnums.ScreenType ScreenType;
    public abstract void Initialize();
    public abstract void Deinitialize();
}
