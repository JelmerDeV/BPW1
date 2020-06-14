using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMovementLoop : MonoBehaviour
{

    public Vector3 startPos;

    public Vector3 targetPos;

    private Vector3 moveTo;

    public float movementSpeed = 4;
    // Start is called before the first frame update
    void Start()
    {
       if(startPos == new Vector3(0, 0, 0))
        {
            startPos = this.transform.position;
        }
        moveTo = targetPos;
        StartCoroutine("MoveObject");

    }

    private void Update()
    {
        this.transform.position = Vector3.LerpUnclamped(transform.position, moveTo, movementSpeed * Time.deltaTime);
     
    }

    IEnumerator MoveObject()
    {
        MoveTo();

        yield return new WaitForSeconds(1);

        MoveFrom();

        yield return new WaitForSeconds(1);

        StartCoroutine("MoveObject");

    }

    private void MoveTo()
    {
        moveTo = targetPos;
    }

    private void MoveFrom()
    {
        moveTo = startPos;
    }

}
