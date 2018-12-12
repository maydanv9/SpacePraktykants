using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public GameObject enemyShip;
    public GameObject bossShip;
    public GameObject weaponUpgrade;
    public GameObject heart;
    public Vector3 asteroidSpawnValue;
    public int waveCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private int rand;
    public TextMeshPro scoreText;
    public TextMeshPro highScore;
    private int scoreNumber;
    public bool gameOver;
    public bool betterWeapon;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject shieldBox;
    public int health = 3;
    public int weaponStateNumber = 0;
    public int shieldStatus;
    public Transform canvas;
    public bool boss = false;


    
    void Start()
    {
        StartCoroutine(SpawnWaves());
        scoreNumber = 0;
        UpdateScore();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (boss == false)
        {

            while (true)
            {
                for (int i = 0; i < waveCount; i++)
                {
                    if (gameOver || boss)
                    {
                        break;
                    }
                    rand = Random.Range(1, 90);
                    //Debug.Log(rand);
                    if (rand > 0 && rand < 15)
                    {
                        Vector3 asteroidSpawnPosition = new Vector3(Random.Range(-asteroidSpawnValue.x, asteroidSpawnValue.x), asteroidSpawnValue.y, asteroidSpawnValue.z);
                        Quaternion spawnRotation = Quaternion.Euler(90, 0, 0);
                        Instantiate(asteroid1, asteroidSpawnPosition, spawnRotation);
                        yield return new WaitForSeconds(spawnWait);
                    }
                    else if (rand >= 15 && rand < 30)
                    {
                        Vector3 asteroidSpawnPosition = new Vector3(Random.Range(-asteroidSpawnValue.x, asteroidSpawnValue.x), asteroidSpawnValue.y, asteroidSpawnValue.z);
                        Quaternion spawnRotation = Quaternion.Euler(90, 0, 0);
                        Instantiate(asteroid2, asteroidSpawnPosition, spawnRotation);
                        yield return new WaitForSeconds(spawnWait);
                    }
                    else if (rand >= 30 && rand < 45)
                    {
                        Vector3 asteroidSpawnPosition = new Vector3(Random.Range(-asteroidSpawnValue.x, asteroidSpawnValue.x), asteroidSpawnValue.y, asteroidSpawnValue.z);
                        Quaternion spawnRotation = Quaternion.Euler(90, 0, 0);
                        Instantiate(asteroid3, asteroidSpawnPosition, spawnRotation);
                        yield return new WaitForSeconds(spawnWait);
                    }
                    else if (rand >= 45 && rand < 80)
                    {
                        Vector3 asteroidSpawnPosition = new Vector3(Random.Range(-asteroidSpawnValue.x, asteroidSpawnValue.x), asteroidSpawnValue.y, asteroidSpawnValue.z);
                        Quaternion spawnRotation = Quaternion.Euler(90, 0, 0);
                        Instantiate(enemyShip, asteroidSpawnPosition, spawnRotation);
                        yield return new WaitForSeconds(spawnWait);
                    }
                    else if (rand >= 80 && rand < 83)
                    {
                        Vector3 asteroidSpawnPosition = new Vector3(Random.Range(-asteroidSpawnValue.x, asteroidSpawnValue.x), asteroidSpawnValue.y, asteroidSpawnValue.z);
                        Quaternion spawnRotation = Quaternion.Euler(90, 0, 0);
                        Instantiate(heart, asteroidSpawnPosition, spawnRotation);
                        yield return new WaitForSeconds(spawnWait);
                    }
                    else if (rand >= 83 && rand < 86)
                    {
                        Vector3 asteroidSpawnPosition = new Vector3(Random.Range(-asteroidSpawnValue.x, asteroidSpawnValue.x), asteroidSpawnValue.y, asteroidSpawnValue.z);
                        Quaternion spawnRotation = Quaternion.Euler(90, 0, 0);
                        Instantiate(weaponUpgrade, asteroidSpawnPosition, spawnRotation);
                        yield return new WaitForSeconds(spawnWait);
                    }
                    else if (rand >= 86 && rand < 89)
                    {
                        Vector3 asteroidSpawnPosition = new Vector3(Random.Range(-asteroidSpawnValue.x, asteroidSpawnValue.x), asteroidSpawnValue.y, asteroidSpawnValue.z);
                        Quaternion spawnRotation = Quaternion.Euler(90, 0, 0);
                        Instantiate(shieldBox, asteroidSpawnPosition, spawnRotation);
                        yield return new WaitForSeconds(spawnWait);
                    }

                }
                yield return new WaitForSeconds(waveWait);
            }
        }

        
    }

    IEnumerator SpawnWaves1()
    {
        yield return new WaitForSeconds(startWait);
        while (boss == true)
        {
            rand = Random.Range(1, 10);
            Debug.Log(rand);
            if (rand == 1)
            {
                Vector3 asteroidSpawnPosition = new Vector3(Random.Range(-asteroidSpawnValue.x, asteroidSpawnValue.x), asteroidSpawnValue.y, asteroidSpawnValue.z);
                Quaternion spawnRotation = Quaternion.Euler(90, 0, 0);
                Instantiate(heart, asteroidSpawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            else if (rand == 2)
            {
                Vector3 asteroidSpawnPosition = new Vector3(Random.Range(-asteroidSpawnValue.x, asteroidSpawnValue.x), asteroidSpawnValue.y, asteroidSpawnValue.z);
                Quaternion spawnRotation = Quaternion.Euler(90, 0, 0);
                Instantiate(weaponUpgrade, asteroidSpawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            else if (rand == 3)
            {
                Vector3 asteroidSpawnPosition = new Vector3(Random.Range(-asteroidSpawnValue.x, asteroidSpawnValue.x), asteroidSpawnValue.y, asteroidSpawnValue.z);
                Quaternion spawnRotation = Quaternion.Euler(90, 0, 0);
                Instantiate(shieldBox, asteroidSpawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    public void AddScore(int newScoreValue)
    {
        scoreNumber += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + scoreNumber;
        if (scoreNumber > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", scoreNumber);
            highScore.text = scoreNumber.ToString();
        }

        if (scoreNumber % 200 == 0 && scoreNumber > 1)
        {
            boss = true;
            Debug.Log("Boss true");
            Vector3 asteroidSpawnPosition = new Vector3(Random.Range(-asteroidSpawnValue.x, asteroidSpawnValue.x), asteroidSpawnValue.y, asteroidSpawnValue.z);
            Quaternion spawnRotation = Quaternion.Euler(90, 0, 0);
            Instantiate(bossShip, asteroidSpawnPosition, spawnRotation);
            waveCount += 10;
            
        }
    }

    public void GameOver()
    {
        scoreText.text = "Your score: " + scoreNumber;
        gameOver = true;
        Time.timeScale = 0;
        canvas.gameObject.SetActive(true);
    }

    

    public void IncreaseHP(int newHP1)
    {
        health += newHP1;
        //Debug.Log("Increasing hp by 1");
        HPUpdate();
    }

    public void ReduceHP(int newHP)
    {
        if (shieldStatus == 0)
        {
            health += newHP;
            //Debug.Log("Reducing hp by 1");
            HPUpdate();
        } else if (shieldStatus == 1)
        {
            HPUpdate();
            ShieldStatusFunction(0);
            shieldStatus = 0;
        }
    }

    public void HPUpdate()
    {
        if (health >= 3) health = 3;

        if (health == 3)
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
        }
        else if (health == 2)
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(false);
        }
        else if (health == 1)
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
        }
        else if (health == 0)
        {
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
            GameOver();
        }
    }
    public void WeaponUpgradeCheck(int weaponState)
    {

        weaponStateNumber += weaponState;
        WeaponUpdate();
    }
    public void WeaponUpdate()
    {
        if (weaponStateNumber >= 1)
        {
            weaponStateNumber = 1;
        }
        else if (weaponStateNumber <= 0)
        {
            weaponStateNumber = 0;
        }
    }

    public void ShieldStatusFunction(int shieldState)
    {
        shieldStatus += shieldState;
        ShieldUpdate();
    }
    public void ShieldUpdate()
    {
        if (shieldStatus >= 1)
        {
            shieldStatus = 1;
        }
        else if (shieldStatus <= 0)
        {
            shieldStatus = 0;
        }
    }

    public void RestartScene()
    {

        SceneManager.LoadScene("GameScene");
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "0";
    }
    
}
