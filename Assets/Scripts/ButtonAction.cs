using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour {
    public GameStateController gameController;

    public Energy energy;
    public GameTime gameTime;
    public Happiness happiness;
    public Work work;

    public uint energyAmountToAdd = 0;
    public uint gameTimeAmountToAdd = 0;
    public uint happinessAmountToAdd = 0;
    public uint workAmountToAdd = 0;

    public uint energyAmountToRemove = 0;
    public uint gameTimeAmountToRemove = 0;
    public uint happinessAmountToRemove = 0;
    public uint workAmountToRemove = 0;

    private bool _isActive = true;

    public void ProcessAll() {
        if (!_isActive) {
            return;
        }
        
        Process(energy, energyAmountToAdd, energyAmountToRemove);
        Process(gameTime, gameTimeAmountToAdd, gameTimeAmountToRemove);
        Process(happiness, happinessAmountToAdd, happinessAmountToRemove);
        Process(work, workAmountToAdd, workAmountToRemove);

        gameController.SwitchState(this);
    }

    private static void Process(Scale scale, uint toAdd, uint toDecrease) {
        if (!scale) {
            return;
        }

        if (toAdd > 0) {
            scale.Increase(toAdd);
        }

        if (toDecrease > 0 && scale.IsEnough(toDecrease)) {
            scale.Decrease(toDecrease);
        }
    }

    public void SetActive(bool state) {
        _isActive = state;
    }
}
