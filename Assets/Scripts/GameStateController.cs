using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour {
    private enum State {
        Main,
        Result,
        DayEnd,
        SessionEnd,
    }

    private State state = default;

    public Canvas canvas;

    public Energy energy;
    public GameTime gameTime;
    public Happiness happiness;
    public Work work;

    public GameObject buttonPrefab;

    private GameObject _workButton;
    private GameObject _playButton;
    private GameObject _householdChoresButton;

    // private ButtonAction _workActionButton;
    // private ButtonAction _playActionButton;
    // private ButtonAction _householdChoresActionButton;

    public void Start() {
        InitiateAll();
        state = State.Main;
    }

    public void InitiateAll() {
        Initiate(ref _workButton, new Vector3(0f, 200.3f, 0f));
        Initiate(ref _playButton, new Vector3(0f, 100.3f, 0f));
        Initiate(ref _householdChoresButton, new Vector3(0f, 0.0f, 0f));
    }

    private void Initiate(ref GameObject button, Vector3 pos) {
        button = Instantiate(buttonPrefab, pos, Quaternion.identity);

        button.transform.SetParent(canvas.transform, false);

        var buttonAction = button.GetComponent<ButtonAction>();

        buttonAction.gameController = this;
    }

    public void NextDay() {
        energy.SetMax();
        gameTime.SetMax();
        work.SetMax();
    }

    public void SwitchState(ButtonAction button) {
        switch (state) {
            // Заглушка
            case State.Main:
                button.energyAmountToRemove += 5;
                break;

            default:
                return;
        }
    }
}
