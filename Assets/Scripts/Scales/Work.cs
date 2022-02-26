using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : Scale
{
    public void Start() {
        Capacity = 8;
        SetAmount(Capacity);
    }
}
