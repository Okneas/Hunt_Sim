using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graf : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curvex;
    [SerializeField] private AnimationCurve _curvey;
    [SerializeField] private AnimationCurve _curvez;
    [SerializeField] private AnimationCurve vel;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        _curvey.AddKey(transform.position.y, Time.deltaTime);
        _curvex.AddKey(transform.position.x, Time.deltaTime);
        _curvez.AddKey(transform.position.z, Time.deltaTime);
    }
}
