using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Corona : MonoBehaviour
{
    [SerializeField] private float _infectionSpeed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        //random init
        transform.position = new Vector3(Random.Range(-11.4f, 11.4f), 5.75f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //move down the virus
        transform.Translate(Vector3.down * Time.deltaTime * _infectionSpeed);
        
        //respawn at top when out of view bot
        if (transform.position.y < -5.75f)
        {
            transform.position = new Vector3(transform.position.x, 5.75f, 0);
        }
        
    }
}
