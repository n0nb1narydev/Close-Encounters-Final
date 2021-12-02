using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : MonoBehaviour
{
    public GameObject drawButton;
    private bool isCropCircled = false;

    private Player player;
    private Animator drawAnim;
    // Start is called before the first frame update
    void Start()
    {
        drawAnim = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(player.isDrawing || isCropCircled)
            {
                drawButton.SetActive(false);
                isCropCircled = true;
                drawAnim.enabled = true;
            }
            else
            {
                drawButton.SetActive(true);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        drawButton.SetActive(false);
    }
}
