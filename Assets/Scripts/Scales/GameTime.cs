using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : Scale {
    public void Start() {
        Capacity = 24;
        SetAmount(Capacity);
    }
}
