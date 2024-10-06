using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float xRotation = 0f;

    public Transform playerBody;


    // Start is called before the first frame update
    void Start()
    {
        // Keep the cursor in the center of the screen
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity *Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * (mouseSensitivity * Time.deltaTime);

        playerBody.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
