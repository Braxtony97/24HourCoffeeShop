using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        UnityEngine.Debug.Log("MainMenu Installer");
    }
}
