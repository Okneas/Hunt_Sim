using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ent : MonoBehaviour
{
    public GameObject animal;
    public bool isCycle = false;
    public Vector3[] _targetCyclepoints;
    private int _targetIndex = 0;

    public float _range = 10f;
    public float _minDist = 5f;
    Vector3 pos;
    public float _speed = 5f;
    private float _lastTimeGo = -1f;
    private float _TimeforIdle = 2f;
    private Vector2 _spawnPoint;
    private Vector2 _targetPoint;

    private void Start()
    {
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (isCycle && _targetCyclepoints.Length > 1)
        {
            _spawnPoint = new Vector2(_targetCyclepoints[_targetIndex].x, _targetCyclepoints[_targetIndex].z);
        }
        else {
            isCycle = false;
            _spawnPoint = new Vector2(transform.position.x, transform.position.z);
        }
    }
    private void Update()
    {
        if (transform.position.y < 0 || transform.position.y > 600)
        {
            transform.position = pos;
        }
        if(_lastTimeGo <= Time.time)
        {
            Vector2 curpos = new Vector2(transform.position.x, transform.position.z);
            Vector2 newpos = Vector2.zero;
            if (isCycle)
            {
                _targetIndex++;
                if(_targetIndex == _targetCyclepoints.Length)
                {
                    _targetIndex = 0;
                }
                newpos = new Vector2(_targetCyclepoints[_targetIndex].x, _targetCyclepoints[_targetIndex].z);
            }
            else
            {
                while (true)
                {
                    newpos = new Vector2(Random.Range(_spawnPoint.x - _range, _spawnPoint.x + _range), Random.Range(_spawnPoint.y - _range, _spawnPoint.y + _range));
                    if (Vector2.Distance(curpos, newpos) >= _minDist)
                    {
                        break;
                    }
                }
                _targetPoint = newpos;
                _lastTimeGo = Time.time + Vector2.Distance(curpos, newpos) / (_speed) + _TimeforIdle;
                transform.LookAt(new Vector3(_targetPoint.x, transform.position.y, _targetPoint.y));
            }
        }
        if(_lastTimeGo - _TimeforIdle > Time.time)
        {
            transform.Translate(0,GetComponent<Rigidbody>().velocity.y * Time.deltaTime, _speed * Time.deltaTime);
        }
    }
}
