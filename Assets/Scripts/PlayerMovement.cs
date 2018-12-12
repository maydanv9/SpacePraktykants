using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float xMin, xMax, zMin, zMax;
    public GameObject playerExplosion;
    public GameObject enemyExplosion;
    public GameObject asteroidExplosion;
    public GameObject bullet;
    public Transform bulletSpawn;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public float fireRate;
    private float nextFire;
    public int scoreValue;
    public int damageTaken;
    public AudioSource playerbullet;
    private GameController gameController;
    public bool weaponState;
    public Transform canvas;
    public int shieldStatusLive;
    public GameObject shield;
    public Transform shieldPos;
    public bool gameIsPaused = false;

    

    public void Start()
    {
        playerbullet = GetComponent<AudioSource>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        shieldStatusLive = 0;
        shield.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    void FixedUpdate()
    {
        float X = Input.GetAxis("Horizontal");
        float Y = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(X, 0.0f, Y);

        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, xMin, xMax),
                0.0f,
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, zMin, zMax)
            );
        
    }

    void Update()
    { if ((Input.GetButton("Fire1")&&Time.time>nextFire) || (Input.GetKey("space") && Time.time > nextFire))
        {
            nextFire = Time.time + fireRate;
            
            if (gameController.weaponStateNumber == 0)
            {
                Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            }
            else if (gameController.weaponStateNumber == 1)
            {
                Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                Instantiate(bullet, bulletSpawn1.position, bulletSpawn1.rotation);
                Instantiate(bullet, bulletSpawn2.position, bulletSpawn2.rotation);
            }            
            playerbullet.Play();
        }
        if (gameController.shieldStatus == 0)
        {
            shield.gameObject.SetActive(false);
        }
        if (Input.GetButtonDown("Cancel"))
        {
            if (gameIsPaused == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shield" && gameController.shieldStatus == 0)
        {
            shield.gameObject.SetActive(true);
            Destroy(other.gameObject);
            gameController.shieldStatus = 1;
        } 
        
    }
 
    public void Pause()
    {
        canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Pause ON");
        gameIsPaused = true;
    }
    public void Resume()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("PauseOFF");
        gameIsPaused = false;
    }
}




