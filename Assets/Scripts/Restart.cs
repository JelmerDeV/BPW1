using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Transform startPos;
    private CharacterController cc;

    private void Start()
    {
        cc = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
            RestartPlayer();


    }

    void RestartPlayer()
    {
        cc.enabled = false;
        gameObject.transform.position = startPos.position;
        gameObject.transform.rotation = startPos.rotation;
        Debug.Log(new Vector3(startPos.position.x, startPos.position.y, startPos.position.z));
        cc.enabled = true;

        Timer.singleton.RestartTimer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Danger")
            RestartPlayer();
    }
}
