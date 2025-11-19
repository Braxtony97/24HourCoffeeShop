using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MoveToScenarioElement : ScenarioElement
{
    [SerializeField] private GirlController _controller;
    [SerializeField] private Transform _point;
    
    public override void StartElement()
    {
        _controller.MoveTo(_point);
    }
}
