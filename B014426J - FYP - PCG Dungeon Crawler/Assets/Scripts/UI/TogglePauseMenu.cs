using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TogglePauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;

    private PlayerinputActions inputActions;
    private bool isPaused = false;

    void Start()
    {
        inputActions = new PlayerinputActions();
        inputActions.Player.Enable();

        inputActions.Player.Pause.performed += PauseButtonPressed;

        pauseUI.SetActive(false);
        isPaused = false;
    }

    private void PauseButtonPressed(InputAction.CallbackContext obj)
    {
        ToggleMenu();
    }

    public void ToggleMenu()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1f;
        } else
        {
            isPaused = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void loadLevel(String levelname)
    {
        SceneManager.LoadScene(levelname);
    }
}
