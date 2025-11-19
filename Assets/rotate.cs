using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [Range(1, 10000)] public int speed;
    [SerializeField] private float _speed = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _speed += speed * Time.deltaTime;
        Vector3 eulerAngles = Vector3.zero;
        eulerAngles.x = _speed;
        transform.eulerAngles = eulerAngles;
    }
}
