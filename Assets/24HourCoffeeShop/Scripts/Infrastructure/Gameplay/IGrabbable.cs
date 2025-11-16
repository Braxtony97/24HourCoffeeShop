using UnityEngine;

public interface IGrabbable
{
    LayerMask LayerMask { get;}
    GameEnums.GrabItems ItemType { get;}
    void Grab(Transform parent);
    void Drop(); 
}
