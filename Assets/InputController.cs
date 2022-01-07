using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private TankController tankController;
    void Awake()
    {
        tankController = GetComponent<TankController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get input value
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        bool jump = Input.GetKey(KeyCode.Space);

        tankController.ForwardInput = vertical;
        tankController.TurnInput = horizontal;
        tankController.JumpInput = jump;
    }
}
