using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    private GameController gameController;
    public int addHP;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameController.health == 3)
        {
            Debug.Log("Current HP: 3 => adding 0 points");
            Destroy(gameObject);
            gameController.IncreaseHP(addHP);
        }
        else if (other.tag == "Player" && gameController.health == 2)
        {
            Debug.Log("Current HP: 2 => adding 1 point");
            Destroy(gameObject);
            gameController.IncreaseHP(addHP);
        }
        else if (other.tag == "Player" && gameController.health == 1)
        {
            Debug.Log("Current HP: 1 => adding 1 point");
            Destroy(gameObject);
            gameController.IncreaseHP(addHP);
        }
            
        }

    }

