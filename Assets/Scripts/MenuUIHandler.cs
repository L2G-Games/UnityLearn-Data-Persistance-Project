using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text bestScoreText;

    private void Start()
    {
        bestScoreText.SetText("Best score: " +
                              GameManager.Instance.bestScoreName +
                              " : " +
                              GameManager.Instance.bestScore);
    }

    public void ReadName()
    {
        string name;
        name = inputField.text;
        Debug.Log("Readname: " + name);
        GameManager.Instance.playerName = name;
    }

    public void StartGame()
    {
        ReadName();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // Original code to quit Unity Player.
#endif
    }
}
