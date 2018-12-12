using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{

    private GameController gameController;
    public int weaponState = 1;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            gameController.WeaponUpgradeCheck(weaponState);
        }

        if (other.tag == "HP")
        {
            return;
        }
    }
    
}
