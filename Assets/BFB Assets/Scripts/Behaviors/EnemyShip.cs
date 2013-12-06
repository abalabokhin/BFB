using UnityEngine;
using System.Collections;
using BFB.Cache;

public class EnemyShip : MonoBehaviour
{
    public GameObject laserLeft;
    public GameObject laserRight;
    public float timeBetweenShots = 5f;
    public float shotLength = 1.5f;
    private float minDistance = 70f;
    private float timeBetweenShotsLeft;
    private float shotLengthLeft;

    // Use this for initialization
    void Start()
    {
        timeBetweenShotsLeft = timeBetweenShots;
        shotLengthLeft = shotLength;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag(Tags.player);
        Vector3 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;
        gameObject.transform.LookAt(player.transform);

        if (distance <= minDistance && timeBetweenShotsLeft > 0 && shotLengthLeft > 0)
        {
            laserLeft.SendMessage("FireForward", false);
            //laserRight.SendMessage("FireForward", false);

        }

        shotLengthLeft -= Time.deltaTime;
        timeBetweenShotsLeft -= Time.deltaTime;

        if (timeBetweenShotsLeft <= 0)
        {
            timeBetweenShotsLeft = timeBetweenShots;
            shotLengthLeft = shotLength;
        }
    }
}
