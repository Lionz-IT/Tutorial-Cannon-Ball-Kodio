using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed;
    public float xDegrees, yDegrees;
    public Transform cannonBody;
    
    void Update()
    {
        cannonMovement();
    }

    void cannonMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        xDegrees += horizontalInput * rotationSpeed * Time.deltaTime;
        yDegrees += verticalInput * rotationSpeed * Time.deltaTime;

        xDegrees = Mathf.Clamp(xDegrees, -43, 43);
        yDegrees = Mathf.Clamp(yDegrees, -7, 45);

        cannonBody.localEulerAngles = new Vector3(0, yDegrees, xDegrees);
    }
}
