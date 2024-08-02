using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private float turnSpeed = 5f;

    [SerializeField]
    private float forwardInput = 0;
    public float ForwardInput
    {
        get 
        { 
            return forwardInput; 
        }

        set
        {
            forwardInput = value;
        }
    }

    [SerializeField]
    private float rotateInput = 0;
    public float RotateInput
    {
        get
        {
            return rotateInput;
        }

        set
        {
            rotateInput = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, rotateInput * turnSpeed * Time.deltaTime);
    }
}
