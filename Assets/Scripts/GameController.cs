using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Panel UI")]
    public GameObject PausePanel;

    public static GameController Instance;

    void Start()
    {
        Instance = this;
        LockCursor(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        // Chỉ khóa chuột khi game có focus và không pause
        if (hasFocus && (PausePanel == null || !PausePanel.activeSelf))
        {
            LockCursor(true);
        }
    }

    void LockCursor(bool isLocked)
    {
        //if (isLocked)
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;
        //}
        //else
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //}
    }

    public void TogglePause()
    {
        bool isPaused = !PausePanel.activeSelf;
        PausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;

        // Khi pause thì mở khóa chuột, khi tiếp tục thì khóa lại
        LockCursor(!isPaused);
    }

    public void ContinueGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        LockCursor(true);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
