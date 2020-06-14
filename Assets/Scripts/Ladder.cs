using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    public GameObject playerOBJ;
    public bool canClimb = false;
    float speed = 5;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            canClimb = true;
           
            playerOBJ = coll.gameObject;
            playerOBJ.GetComponent<CharacterController>().enabled = false;
        }
    }

    void OnCollisionExit(Collision coll2)
    {
        if (coll2.gameObject.tag == "Player")
        {
            canClimb = false;
            playerOBJ.GetComponent<CharacterController>().enabled = true;
            playerOBJ = null;
        }
    }
    void Update()
    {
        if (canClimb)
        {
            if (Input.GetKey(KeyCode.W))
            {
               // Debug.Log("AAAAH");
               
                playerOBJ.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);

            }
            if (Input.GetKey(KeyCode.S))
            {
                playerOBJ.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
                if (playerOBJ.GetComponent<PlayerMovement>().isGrounded)
                {
                    canClimb = false;
                    playerOBJ.GetComponent<CharacterController>().enabled = true;
                }
            }
        }
    }
}
