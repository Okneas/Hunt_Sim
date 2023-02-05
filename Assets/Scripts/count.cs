using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class count : MonoBehaviour
{
    Text points;
    // Start is called before the first frame update
    void Start()
    {
        points = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        points.text = Bullet.ps.ToString();
    }
}
