using UnityEngine;
public class Cam_Controller : MonoBehaviour
{
    public float velcam; //velocidad de la cámara
    public float rotX; //rotación de la cámara
    public float rotY; //rotación de la cámara
    public Transform playerTransform; //El "Transform" que regula la posición del jugador
    public Transform cameraTransform;

    
    void Start()
    {
        //Init vars
        velcam = 3.0f;
        rotX = 0;
        rotY = 0;
        playerTransform = transform;
    }

    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * velcam;
        float mouseY = Input.GetAxis("Mouse Y") * velcam;
        
        //rotX -= mouseY;
        //rotX = Mathf.Clamp(rotX, -10f, 10f);
        rotY -= mouseX;
        //rotY = Mathf.Clamp(rotY, -110f, 110f);
        
        playerTransform.localRotation = Quaternion.Euler(0,-rotY,0);

        //playerTransform.Rotate(Vector3.up*rotY);
    }
}
