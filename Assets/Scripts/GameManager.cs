using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int waveNumber = 0;
    public GameObject myPrefab;
    public static int score = 0;
    public static int livesLeft = 2;
    public int highScore = 0;

    void Start()
    {
        if (highScore == 0)
        {
            highScore = PlayerPrefs.GetInt("highScore", 0);
            Debug.Log("High Score is: " + highScore);
        }
        SpawnMoreAndMore();
    }

    public void SpawnOne()
    {

        GameObject newlyCreated =
            Object.Instantiate(myPrefab);
        newlyCreated.transform.position =
            new Vector3(Random.Range(-10, 10), Random.Range(1, 16), Random.Range(20, 30));
        newlyCreated.transform.LookAt(Camera.main.transform);
    }


    public void SpawnMoreAndMore()
    {
        if (waveNumber > 10)
        {
            return;
        }

        waveNumber += 2;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnOne();
        }
        Invoke("SpawnMoreAndMore", 3);
    }


    public void EndLife()
    {
        if (livesLeft <= 0)
        {
            Debug.Log("Game Over! You scored " + score);
            if (score > highScore)
            {
                Debug.Log("New High Score!!!");
                highScore = score;
                PlayerPrefs.SetInt("highScore", highScore);
            }
            livesLeft = 2;
            score = 0;
        }
        else
        {
            livesLeft--;
            Debug.Log("Oops! You have " + livesLeft + " lives left");
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}