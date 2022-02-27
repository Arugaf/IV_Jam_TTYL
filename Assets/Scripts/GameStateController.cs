using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
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

    public Button resultWindow;

    private GameObject _workButton;
    private GameObject _playButton;
    private GameObject _householdChoresButton;

    private enum WorkState {
        Positive,
        Negative,
    }

    private WorkState _workState;

    private enum PlayState {
        Positive,
        Negative,
    }

    private PlayState _playState;

    private enum HouseholdChoresState {
        Positive,
        Negative,
    }

    private HouseholdChoresState _householdChoresState;

    private ButtonAction _workActionButton;
    private ButtonAction _playActionButton;
    private ButtonAction _householdChoresActionButton;

    public void Start() {
        InitiateAll();
        state = State.Main;
    }

    public void InitiateAll() {
        Initiate(ref _workButton, new Vector3(-195f, 216f, 0f));
        Initiate(ref _playButton, new Vector3(525f, 37f, 0f));
        Initiate(ref _householdChoresButton, new Vector3(-500f, 0.0f, 0f));

        _workActionButton = _workButton.GetComponent<ButtonAction>();
        _playActionButton = _playButton.GetComponent<ButtonAction>();
        _householdChoresActionButton = _householdChoresButton.GetComponent<ButtonAction>();

        _workActionButton.gameTime = gameTime;
        _workActionButton.energy = energy;
        _workActionButton.work = work;
        _workActionButton.happiness = happiness;

        _playActionButton.gameTime = gameTime;
        _playActionButton.energy = energy;
        _playActionButton.happiness = happiness;

        _householdChoresActionButton.gameTime = gameTime;
        _householdChoresActionButton.energy = energy;
        _householdChoresActionButton.happiness = happiness;
        
        gameTime.SetMax();
        energy.SetMax();
        happiness.SetAmount(50);
        work.SetAmount(0);
        
        SetRandomPlayState();
        SetRandomWorkState();
        SetRandomHouseholdChoresState();
        
        // var image = Resources.Load<Sprite>("Images/Scales/Счастье");
        happiness.GetComponentInParent<RectTransform>().sizeDelta = happiness.GetComponentInParent<Image>().sprite.rect.size;
        energy.GetComponentInParent<RectTransform>().sizeDelta = energy.GetComponentInParent<Image>().sprite.rect.size;
        work.GetComponentInParent<RectTransform>().sizeDelta = work.GetComponentInParent<Image>().sprite.rect.size;

        var image = Resources.Load<Sprite>("Images/DoS");
        _workButton.GetComponent<Image>().sprite = image;
        _workButton.GetComponent<RectTransform>().sizeDelta = image.rect.size;
        
        image = Resources.Load<Sprite>("Images/игры");
        _playButton.GetComponent<Image>().sprite = image;
        _playButton.GetComponent<RectTransform>().sizeDelta = image.rect.size;
        
        image = Resources.Load<Sprite>("Images/котик");
        _householdChoresButton.GetComponent<Image>().sprite = image;
        _householdChoresButton.GetComponent<RectTransform>().sizeDelta = image.rect.size;
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

    public void SetRandomWorkState() {
        _workState = WorkState.Negative;

        switch (_workState) {
            case WorkState.Negative: {
                _workActionButton.gameTimeAmountToRemove = 5;
                _workActionButton.energyAmountToRemove = 9;
                _workActionButton.workAmountToAdd = 5;
                _workActionButton.happinessAmountToRemove = 3;
                break;
            }
        }
    }

    public void SetRandomPlayState() {
        _playState = PlayState.Negative;

        switch (_playState) {
            case PlayState.Negative: {
                _playActionButton.gameTimeAmountToRemove = 4;
                _playActionButton.energyAmountToAdd = 1;
                _playActionButton.happinessAmountToAdd = 3;
                break;
            }
        }
    }

    public void SetRandomHouseholdChoresState() {
        _householdChoresState = HouseholdChoresState.Negative;

        switch (_householdChoresState) {
            case HouseholdChoresState.Negative: {
                _householdChoresActionButton.gameTimeAmountToRemove = 3;
                _householdChoresActionButton.energyAmountToRemove = 2;
                _playActionButton.happinessAmountToRemove = 1;
                break;
            }
        }
    }

    public void ShowResult(string path) {
        var image = Resources.Load<Sprite>(path);
        resultWindow.GetComponent<Image>().sprite = image;
        resultWindow.GetComponent<RectTransform>().sizeDelta = image.rect.size;
        resultWindow.gameObject.SetActive(true);
    }

    public void ActivateBack() {
        _playButton.SetActive(true);
        _workButton.SetActive(true);
        _householdChoresButton.SetActive(true);
    }

    public void SwitchState(ButtonAction button) {
        ShowResult("Images/выбор мема");
        _playButton.SetActive(false);
        _workButton.SetActive(false);
        _householdChoresButton.SetActive(false);

        switch (state) {
            // Заглушка
            case State.Main:
                if (button == _playActionButton) {
                    switch (_playState) {
                        case PlayState.Negative: {
                            // ShowResult("Images/выбор мема.PNG");
                            break;
                        } 
                    }
                    
                    SetRandomPlayState();
                } else if (button == _workActionButton) {
                    SetRandomWorkState();
                } else if (button == _householdChoresActionButton) {
                    SetRandomHouseholdChoresState();
                }
                
                break;

            default:
                return;
        }
    }
}
