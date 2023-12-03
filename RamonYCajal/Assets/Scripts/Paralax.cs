using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float _lenght, _startpos;
    private Camera _camera;
    public float _paralaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        _startpos = transform.position.x;
        _camera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (_camera.transform.position.x * _paralaxEffect);
        transform.position = new Vector3(_startpos+dist, transform.position.y, transform.position.z);
    }
}
