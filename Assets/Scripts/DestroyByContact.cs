using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
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
        //If asteroid collides with boundary, then ignore it.
        if (other.tag == "Boundary")
        {
            return;
        }
        //If asteroid collides with player, reduce his HP or destroy if HP is zero.
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(asteroidExplosion, transform.position, transform.rotation);
            gameController.AddScore(scoreValue);
            gameController.ReduceHP(damageTaken);
            gameController.WeaponUpgradeCheck(-1);
            Instantiate(playerHitSound);
            //Debug.Log("Collision bullet/player");
            if (gameController.health == 0)
            {
                Instantiate(asteroidExplosion, transform.position, transform.rotation);
                Instantiate(playerExplosion, transform.position, transform.rotation);
                Destroy(other.gameObject);
                Destroy(gameObject);
                gameController.GameOver();
            }
        }
        //If asteroid touches bullet, destroy both.
        if (other.tag == "PlayerBullet")
        {
            Instantiate(asteroidExplosion, transform.position, transform.rotation);
            Destroy(other.gameObject);//destroy bullet
            Destroy(gameObject);//destroy asteroid
            gameController.AddScore(scoreValue);
        }
        //If asteroid touches other one, ignore it.
        if (gameObject.tag == "Asteroid")
        {
            return;
        }

        //If enemy bullet touhes asteroid, ignore it.
        if (gameObject.tag == "EnemyBullet")
        {
            return;
        }

    }

}
