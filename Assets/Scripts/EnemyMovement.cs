using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;

public class EnemyMovement : MonoBehaviour {

    public GameObject bullet;
    public Transform bulletSpawn;
    public float fireRate;
    private float nextFire;
    public float fireDelay;
    
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

    void Start ()
    {
        enemyBullet = GetComponent<AudioSource>();
        InvokeRepeating("Fire", fireDelay, fireRate);
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
        StartCoroutine(Evade());
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
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
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
}
