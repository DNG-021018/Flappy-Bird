using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Movement player;
    public Spawner spawner;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOver.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1;
        spawner.enabled = true;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        spawner.enabled = false;
        player.enabled = false;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    public void IncreseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
