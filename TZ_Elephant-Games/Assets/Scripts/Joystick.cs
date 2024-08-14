using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(ButtonProvaider))]
public class Joystick : MonoBehaviour
{
    private float maxDistance;

    private bool isUse;

    private Vector3 direction;

    private Color joystickColor;
    private Color joystickBackColor;

    private Image joystickImage;
    private Image joystickBackImage;

    [SerializeField]
    private ButtonProvaider buttonProvaider;
    [SerializeField]
    private Transform joystickTransform;

    [SerializeField]
    private float horizontal;
    public float Horizontal
    {
        get
        {
            return horizontal;
        }

        private set
        {
            horizontal = value;
        }
    }

    [SerializeField]
    private float vertical;
    public float Vertical
    {
        get
        {
            return vertical;
        }

        private set
        {
            vertical = value;
        }
    }

    protected virtual void Awake()
    {
        buttonProvaider.PointerDown += ButtonProvaider_PointerDown;
        buttonProvaider.PointerUp += ButtonProvaider_PointerUp;

        maxDistance = (GetComponent<RectTransform>().rect.height) / 2;

        joystickImage = joystickTransform.GetComponent<Image>();
        joystickBackImage = GetComponent<Image>();
        joystickColor = joystickImage.color;
        joystickBackColor = joystickBackImage.color;
        joystickImage.color = Color.clear;
        joystickBackImage.color = Color.clear;
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
            joystickImage.color = joystickColor;
            joystickBackImage.color = joystickBackColor;

            if (Vector3.Distance(transform.position, Input.mousePosition) < maxDistance)
            {
                joystickTransform.position = Input.mousePosition;
            }
            else
            {
                direction = Input.mousePosition - transform.position;
                joystickTransform.position = transform.position + (direction.normalized * maxDistance);
            }

            horizontal = joystickTransform.localPosition.x / maxDistance;
            vertical = joystickTransform.localPosition.y / maxDistance;
        }
        else
        {
            joystickImage.color = Color.clear;
            joystickBackImage.color = Color.clear;

            joystickTransform.transform.localPosition = new Vector3();
            horizontal = 0;
            vertical = 0;
        }
    }
}

