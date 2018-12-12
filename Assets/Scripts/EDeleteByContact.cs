using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDeleteByContact : MonoBehaviour {
    public GameObject playerExplosion;
    public GameObject enemyExplosion;
    public GameObject playerHitSound;
    public int scoreValue;
    public int damageTaken;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet" && tag == "EnemyShip")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(enemyExplosion,transform.position, transform.rotation);
            gameController.AddScore(scoreValue);
        }

        if (other.tag == "Player")
        {
            Destroy(gameObject);
            gameController.ReduceHP(damageTaken);
            gameController.WeaponUpgradeCheck(-1);
            Instantiate(playerHitSound);
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            Debug.Log("Collision enemy/player - reducing 1 HP");

            if (gameController.health == 0)
            {
                Instantiate(playerExplosion, transform.position, transform.rotation);
                Destroy(other.gameObject);
                gameController.GameOver();
                
            }
        }
        
    }
}
