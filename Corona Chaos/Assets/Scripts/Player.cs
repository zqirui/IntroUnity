using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] //make it still accessible in the Unity Editor
    public float _speed = 6f;

    [SerializeField] 
    private GameObject _vaccinePrefab;
    // Start is called before the first frame update
    [SerializeField] 
    private float _vaccinationRate = 0.4f;

    private float _canVaccinate = -1f;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Vaccinate();
    }

    void Vaccinate()
    {
        //if space is pressed => instantiate vaccine prefab
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canVaccinate)
        {
            //determine next spawnable time
            _canVaccinate = Time.time + _vaccinationRate;
            Debug.Log("space bar pressed");
            Instantiate(_vaccinePrefab, transform.position + new Vector3(0,0.7f,0) , Quaternion.identity);
        }
    }
    
    //player movement function
    void PlayerMovement()
    {
        //read player input on x and y axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * _speed * verticalInput);
        
        //set player boundaries
        if (transform.position.y > 0)
        {
            //keep player y position at 0
            transform.position = new Vector3(transform.position.x, 0f, 0f);
        } 
        else if (transform.position.y < -5.5f)
        {
            //keep player within the lower boundary
            transform.position = new Vector3(transform.position.x, -5.5f, 0f);
        }
        else if (transform.position.x < -11.4f)
        {
            //teleport player to the opposite boundary
            transform.position = new Vector3(11.4f, transform.position.y, 0f);
        }
        else if (transform.position.x > 11.4f)
        {
            transform.position = new Vector3(-11.4f, transform.position.y, 0f);
        }
    }
}
