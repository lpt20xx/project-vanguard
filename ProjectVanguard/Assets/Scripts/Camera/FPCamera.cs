using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class FPCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float cameraVerticalRotation = 0f;
    //[SerializeField] private float aimDuration = 0.3f;

    public bool lockedCursor = false;

    // Start is called before the first frame update
    private void Start()
    {
        this.LockCursor();
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        this.GetMouseInput();
    }


    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lockedCursor = true;

        
    }

    private void GetMouseInput()
    {
        if (PlayerHealth.isDead)
        {
            return;
        }

        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        //rotate camera vertical
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
        //rotate camera horizontal
        player.Rotate(Vector3.up * inputX);
    }


}
