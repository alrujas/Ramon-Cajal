using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private int _offSetY;

    [SerializeField] private int _offSetX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(_target.position.x+_offSetX, _target.position.y+_offSetY);
    }
}
