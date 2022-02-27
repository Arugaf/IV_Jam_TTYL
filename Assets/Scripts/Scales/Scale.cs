using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Scale : MonoBehaviour {
    protected uint Capacity;
    public uint amount;

    public void SetAmount(uint amt) {
        amount = amt;
    }

    public void SetMax() {
        amount = Capacity;
    }

    public void Increase(uint amt) {
        amount = amount + amt < Capacity ? amount + amt : Capacity;
    }

    public void Decrease(uint amt) {
        amount = amount - amt > 0 ? amount - amt : 0;
    }

    public bool IsEnough(uint amt) {
        return (int)amount - (int)amt > 0;
    }
}
