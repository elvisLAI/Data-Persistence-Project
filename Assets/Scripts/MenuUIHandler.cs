using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        string username = GameManager.instance.bestScore.username;
        int score = GameManager.instance.bestScore.score;
        HighScoreText.text = $"Best Score: {username} {score}";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        if (GameManager.instance.username == "")
        {
            GameManager.instance.username = "Anonymous";
        }
        SceneManager.LoadScene(1);
    }

    public void HandleOnNameChange(string username)
    {
        GameManager.instance.username = username;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
