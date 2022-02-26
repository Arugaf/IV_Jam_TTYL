using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameTime : Scale {
    public void Start() {
        Capacity = 24;
        SetAmount(Capacity);
    }
}
