using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public Text points;
    [SerializeField] private AnimationCurve vel;
    public static int ps = 0;
    Vector3 g = new Vector3(0, -9.81f, 0);
    float windz;
    float windx;
    float windy;
    Rigidbody rb;
    public float bulletLife = 3;
    public float mass = 0.013f;
    Vector3 a;
    Vector3 wind;
    float h;
    Vector3 v, v1;
    float vmax = 400f;
    Vector3 xyz1, xyz;
    bool inFly = true;
    float t = 0f;

    private Vector3 accel(Vector3 g, float h, Vector3 v, Vector3 wind, float vmax)
    {
        return g - Mathf.Exp(-h / 10000) * g.magnitude * (v - wind) * (v - wind).magnitude / (vmax * vmax);
    }


    private void VerletPredKorr(Vector3 g, ref Vector3 r, ref Vector3 v, float vmax, Vector3 wind)
    {
        Vector3 a = new Vector3();
        Vector3 vPred = new Vector3();
        a = accel(g, r.y, v, wind, vmax);
        r += v * Time.fixedDeltaTime + 0.5f * a * Time.fixedDeltaTime * Time.fixedDeltaTime;
        vPred = v + a * Time.fixedDeltaTime;
        v += 0.5f * a * Time.fixedDeltaTime;
        a = accel(g, r.y, vPred, wind, vmax);
        v += 0.5f * a * Time.fixedDeltaTime;
    }


    private void Start()
    {
        points = GetComponent<Text>();
        rb = GetComponent<Rigidbody>();
        xyz.y = gameObject.transform.position.y;
        v = 100 * rb.transform.forward;
        windx = Random.Range(-10, 10);
        windy = Random.Range(-10, 10);
        windz = Random.Range(-10, 10);
        wind = new Vector3(windx, windy, windz);
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (inFly)
        {
            VerletPredKorr(g, ref xyz, ref v, vmax, wind);
            vel.AddKey(t, v.magnitude);
            transform.rotation = Quaternion.LookRotation(v);
            t += Time.fixedDeltaTime;
            rb.velocity = v;
        }
    }

    private void Awake()
    {
        Destroy(gameObject, bulletLife);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "animal" && inFly)
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ps++;
        }
        inFly = false;
        rb.constraints = RigidbodyConstraints.FreezeAll; 
    }
}
