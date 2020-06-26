using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    static manager instance;

    public Text Scoure;
    public GameObject GameOverUI;
    public GameObject GamePauseUI;
    public GameObject GamePlayUI;
    public Transform player;
    int bestScoure;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        bestScoure = Mathf.Max(bestScoure,(int)(34f*player.position.y));

        Scoure.text = "Score:" + bestScoure.ToString("0");
    }

    public void PauseGame()
    {
        instance.GamePauseUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PlayGame()
    {
        instance.GamePlayUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ContinueGame()
    {
        instance.GamePauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public static void GameOver(bool dead)
    {
        if (dead)
        {
            instance.GameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
