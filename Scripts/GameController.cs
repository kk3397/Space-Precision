using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public Text livesText;
    private int score;

    private int playerLives;
    public bool isDead;

     void Start()
    {
       
        score = 0;
        UpdateScore();
        playerLives = 3;
        UpdateLives();
        isDead = false;

        StartCoroutine(SpawnWaves());
      
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);// waits for the game to start
        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazards, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);// waits for hazards to appear
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
   public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void LiveCount()
    {
        playerLives--;
        UpdateLives();
        if (playerLives <= 0)
        {
            isDead = true;
        }
    }
    public void UpdateLives()
    {
        livesText.text = "Lives: " + playerLives;
    }
}
