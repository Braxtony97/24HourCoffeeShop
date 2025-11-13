using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader 
{
    private ICoroutineRunner _coroutineRunner;

    [Inject]
    public SceneLoader(ICoroutineRunner coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;
    }

    public void LoadScene (string sceneName, Action onLoaded = null)
    {
        _coroutineRunner.StartCoroutine(LoadSceneWithCoroutine(sceneName, onLoaded));
    }

    private IEnumerator LoadSceneWithCoroutine(string sceneName, Action onLoaded)
    {
        if (SceneManager.GetActiveScene().name == sceneName)
        {
            onLoaded?.Invoke();
            yield break;
        }

        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName);

        while (!waitNextScene.isDone)
        {
            yield return null;
        }

        onLoaded?.Invoke();
    }
}
