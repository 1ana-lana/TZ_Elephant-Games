using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        playerController.ForwardInput = joystick.ForceY;
        playerController.RotateInput = joystick.ForceX;
    }
}
