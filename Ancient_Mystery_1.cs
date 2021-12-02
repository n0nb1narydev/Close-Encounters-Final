using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ancient_Mystery_1 : MonoBehaviour
{
    private Player player;
    public GameObject pyramid;
    public GameObject buildButton;

    public bool isBuilt = false;

    public GameObject alien;
    public GameObject walkButton;

    public AudioSource beamdownSound;

    public bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!isBuilt)
            {
                buildButton.SetActive(true);
            }
            if (player.isBuilding)
            {
                isBuilt = true;
                buildButton.SetActive(false);
                pyramid.SetActive(true);
            }
            if(isBuilt)
            {
                 walkButton.SetActive(true);
            }
            if (player.isBeamingDown || isWalking)
            {
                 isWalking = true;
                 beamdownSound.Play();
                 walkButton.SetActive(false);
                 alien.SetActive(true);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        buildButton.SetActive(false);
        walkButton.SetActive(false);
}
}
