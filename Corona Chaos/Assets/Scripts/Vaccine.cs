using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Vaccine : MonoBehaviour
{
    [SerializeField] private float _speed = 7.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);
        
        //delete vaccine when out of game view
        if (transform.position.y > 7f)
        {
            Destroy(this.gameObject);
        }
    }
}
