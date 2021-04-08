using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{

    [SerializeField] Text _currentScoreTextView;
    [Header("Enemy Spawn Settings")]
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnTime = 2f;
    private float InstantiationTimer = 2f;

    int _currentScore;

    private void Update()
    {

        // Exit Level
        //TODO bring up popup menu for navigation

        SpawnEnemyRandomLocation();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitLevel();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            //Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            //SpawnEnemyRandomLocation();
        }
    }
    public void ExitLevel()
    {
        // compare to high score
        int highScore = PlayerPrefs.GetInt("HighScore");
        if(_currentScore > highScore)
        {
            // save the current score as the new high score
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New high score: " + _currentScore);
        }
        // load new level
        SceneManager.LoadScene("MainMenu");
    }

    public void IncreaseScore(int scoreIncrease)
    {
        // increase score
        _currentScore += scoreIncrease;
        // update score display, so we can see the new score
        _currentScoreTextView.text =
            "Score: " + _currentScore.ToString();
    }

    void ReloadLevel()
    {
        int activeSceneIndex =
            SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }

    void SpawnEnemyRandomLocation()
    {
        //Time intervals
        InstantiationTimer -= Time.deltaTime;
        if(InstantiationTimer <= 0)
        {
            //choose a random spawn index from our spawn location array
            int newSpawnIndex = Random.Range(0, spawnPoints.Length);
            //create a new object at the randomly selected spawn position and rotation
            Instantiate(objectToSpawn, spawnPoints[newSpawnIndex].position, spawnPoints[newSpawnIndex].rotation);
            InstantiationTimer = spawnTime;
        }
      
    }

}
