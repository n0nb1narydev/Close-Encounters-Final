using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public int speed;
    private Player player;

    private bool playerInCloud = false;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.z > 550f)
        {
            float randomX = Random.Range(-180f, 810f);
            transform.position = new Vector3(randomX, 78f, -727);
        }

            if (Time.time > nextActionTime)
            {
                nextActionTime = Time.time + period;

                if (playerInCloud)
                {
                    if (player.Exposure > 0)
                    {
                        player.Exposure -= 1;
                    }
                }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInCloud = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        playerInCloud = false;
    }
}
