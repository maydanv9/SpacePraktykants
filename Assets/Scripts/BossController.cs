using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public GameObject bullet;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public Transform bulletSpawn3;
    public Transform bulletSpawn4;
    public float fireRate;
    public GameObject enemyExplosion;
    private float nextFire;
    public float fireDelay;
    private GameController gameController;
    public AudioSource enemyBullet;

    //Movement
    public float dodge;
    public float smoothing;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public float xMin, xMax, zMin, zMax;
    private float currentSpeed;
    private float targetManeuver;
    private Rigidbody rb;
    private float bossHP;

    void Start()
    {
        enemyBullet = GetComponent<AudioSource>();
        InvokeRepeating("Fire", fireDelay, fireRate);
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
        StartCoroutine(Evade());
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        bossHP = 20;
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    void Fire()
    {
        Instantiate(bullet, bulletSpawn1.position, bulletSpawn1.rotation);
        Instantiate(bullet, bulletSpawn2.position, bulletSpawn1.rotation);
        Instantiate(bullet, bulletSpawn3.position, bulletSpawn1.rotation);
        Instantiate(bullet, bulletSpawn4.position, bulletSpawn1.rotation);
        enemyBullet.Play();
    }

    void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.x, targetManeuver, smoothing * Time.deltaTime);
        GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, xMin, xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, zMin, zMax)
        );
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            gameController.GameOver();
        }

        if (other.tag == "PlayerBullet")
        {
            BossReduceHP(-1);
            Destroy(other.gameObject);
        }

    }
    void BossReduceHP(int dmg)
    {
        bossHP += dmg;
        UpdateBossHP();
    }

    void UpdateBossHP()
    {
        Debug.Log(bossHP);
        if (bossHP == 0)
        {
            gameController.boss = false;
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            gameController.AddScore(50);
        }
    }

}