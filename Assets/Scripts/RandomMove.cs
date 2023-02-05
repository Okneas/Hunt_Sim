using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    public float RAY = 5.0f;
    public float moveSpeed = 5.0f;
    public float rotSpeed = 10.0f;

    public int moveDir = 1;

    private float tiempo1;
    private float tiempo2;
    private float tiempo3;

    public bool Walk;
    public float random = 0.1f;
    public float a_WalkSpeed = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        tiempo1 = Random.Range(0, 500);
        tiempo2 = Random.Range(0, 500);
        tiempo3 = Random.Range(0, 500);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!Physics.Raycast(transform.position, transform.forward, RAY))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.smoothDeltaTime);
        }
        else {
            if (Physics.Raycast(transform.position, -transform.right, 1))
            {
                moveDir = 1;
            }
            else if (Physics.Raycast(transform.position, transform.right, 1))
            {
                moveDir = -1;
            }
            transform.Rotate(Vector3.up, 90 * rotSpeed * Time.smoothDeltaTime * moveDir);
        }
        if (Physics.Raycast(transform.position, transform.forward, 0.5f))
        {
            transform.Rotate(Vector3.up, 180 * rotSpeed/4 * Time.smoothDeltaTime);
        }
        tiempo1 -= Time.deltaTime * 1;
        tiempo2 -= Time.deltaTime * 1;
        tiempo3 -= Time.deltaTime * 1;
        if(tiempo1 <= 0)
        {
            tiempo1 = Random.Range(0, 500);
        }
        if (tiempo2 <= 0)
        {
            tiempo2 = Random.Range(0, 500);
        }
        if (tiempo3 <= 0)
        {
            tiempo3 = Random.Range(0, 500);
        }
        if (tiempo1 > 300)
        {
            Walk = true;
            moveSpeed = 2;
        }
        if (tiempo1 < 150)
        {
            Walk = false;
            moveSpeed = 0;
        }
        if (tiempo2 < 75 && Walk == true)
        {
            transform.Rotate(Vector3.up, 90 * rotSpeed * Time.smoothDeltaTime * moveDir);
        }
        if (tiempo2 > 450 && Walk == true)
        {
            transform.Rotate(Vector3.up, -90 * rotSpeed * Time.smoothDeltaTime * moveDir);
        }

    }
}
