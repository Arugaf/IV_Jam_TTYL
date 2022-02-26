using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : Scale {
    public void Start() {
        Capacity = 100;
        SetAmount(Capacity);
    }
}
