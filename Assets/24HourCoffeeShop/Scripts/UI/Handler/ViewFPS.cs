using TMPro;
using UnityEngine;

public class ViewFPS : MonoBehaviour
{
    [SerializeField] private TMP_Text _fpsText;

    private float _fps;

    void Start() => 
        InvokeRepeating("GetFPS", 1, 1);

    private void GetFPS()
    {
        _fps = (int)(1f / Time.unscaledDeltaTime);
        _fpsText.text = _fps.ToString();
    }
}
