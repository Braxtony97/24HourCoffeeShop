using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScreenController : MonoBehaviour
{
    public BaseScreen CurrentScreen => _currentScreen;

    [SerializeField] private BaseScreen[] _screens;
    [SerializeField] private Transform _canvas;

    private BaseScreen _currentScreen;
    private DiContainer _container;

    [Inject]
    public void Construct(DiContainer container)
    {
        _container = container;
    }

    public void CreateScreen(GameEnums.ScreenType screenType)
    {
        DestroyCurrentScreen();

        foreach (BaseScreen screen in _screens)
        {
            if (screen.ScreenType == screenType)
            {
                BaseScreen newScreen = _container.InstantiatePrefabForComponent<BaseScreen>(screen);
                newScreen.transform.SetParent(_canvas, false);

                _currentScreen = newScreen;
                _currentScreen.Initialize();
            }
        }
    }

    public void DestroyCurrentScreen()
    {
        if (_currentScreen != null)
        {
            _currentScreen.Deinitialize();
            Destroy(_currentScreen.gameObject);
        }
    }
}
