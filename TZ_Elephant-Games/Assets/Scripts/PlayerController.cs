using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject body;
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

    // Update is called once per frame
    void Update()
    {
        if (forwardInput == 0 && rotateInput == 0) 
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            transform.Translate(transform.forward * Time.deltaTime * speed * forwardInput);
            transform.Translate(transform.right * Time.deltaTime * speed * rotateInput);
            body.transform.LookAt(transform.localPosition + new Vector3(rotateInput, 0, forwardInput));
        }
    }
}
