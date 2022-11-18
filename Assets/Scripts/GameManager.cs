using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
            //GAME OVER SCENE
    public static bool isGameOver;
    public GameObject gameOverScreen;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    private void Awake()
    {
        isGameOver = false;
    }

    private void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CallMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}