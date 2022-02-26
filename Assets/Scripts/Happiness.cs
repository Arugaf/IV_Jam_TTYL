using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happiness : MonoBehaviour {
    private const uint Capacity = 100;
    [Range(0, 100)] public uint amount;

    public void SetAmount(uint amt = Capacity) {
        amount = amt;
    }

    public void Increase(uint amt) {
        amount = amount + amt < Capacity ? amount + amt : Capacity;
    }

    public void Decrease(uint amt) {
        amount = amount - amt > 0 ? amount - amt : 0;
    }

    public void Start() {
        SetAmount();
    }
}
