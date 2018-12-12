using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    //private GameController gameController;
    public int shieldLocalStatus;

    void Start()
    {
        //GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        //gameController = gameControllerObject.GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
       /* if (other.tag == "Player")
        {
            Debug.Log("Collision with player, adding shield");
            Destroy(gameObject);
            gameController.ShieldStatusFunction(shieldLocalStatus);
        }*/
    }
}
