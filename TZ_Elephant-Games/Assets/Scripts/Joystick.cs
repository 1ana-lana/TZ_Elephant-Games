using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ButtonProvaider))]
public class Joystick : MonoBehaviour
{
    private float maxDistance;

    private bool isUse;

    private Vector3 direction;

    [SerializeField]
    private ButtonProvaider buttonProvaider;
    [SerializeField]
    private Transform joystickImage;

    [SerializeField]
    private float forceX;
    public float ForceX
    {
        get
        {
            return forceX;
        }

        private set
        {
            forceX = value;
        }
    }

    [SerializeField]
    private float forceY;
    public float ForceY
    {
        get
        {
            return forceY;
        }

        private set
        {
            forceY = value;
        }
    }

    protected virtual void Awake()
    {
        buttonProvaider.PointerDown += ButtonProvaider_PointerDown;
        buttonProvaider.PointerUp += ButtonProvaider_PointerUp;

        maxDistance = (GetComponent<RectTransform>().rect.height) / 2;
    }

    private void ButtonProvaider_PointerUp(PointerEventData e)
    {
        isUse = false;
    }

    private void ButtonProvaider_PointerDown(PointerEventData e)
    {
        isUse = true;
    }

    public void Update()
    {
        if (isUse)
        {
            if (Vector3.Distance(transform.position, Input.mousePosition) < maxDistance)
            {
                joystickImage.position = Input.mousePosition;
            }
            else
            {
                direction = Input.mousePosition - transform.position;
                joystickImage.position = transform.position + (direction.normalized * maxDistance);
            }

            forceX = joystickImage.localPosition.x / maxDistance;
            forceY = joystickImage.localPosition.y / maxDistance;
        }
        else
        {
            joystickImage.transform.localPosition = new Vector3();
            forceX = 0;
            forceY = 0;
        }
    }
}

