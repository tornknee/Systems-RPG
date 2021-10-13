using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField]
    float mouseSensitivity;

    [SerializeField]
    float maxHeight;
    [SerializeField]
    float minHeight;

    Transform camRig;
    float rotX;

    // Start is called before the first frame update
    void Start()
    {
        camRig = transform.Find("CameraRig");
        if(camRig == null)
        {
            Debug.LogError("CameraRig not found, did you change it's name?");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameM.paused)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity);

            rotX += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
            rotX = Mathf.Clamp(rotX, maxHeight, minHeight);

            camRig.transform.localEulerAngles = Vector3.left * rotX;
        }
    }
}
