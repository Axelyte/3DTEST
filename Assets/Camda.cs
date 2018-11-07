using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camda : MonoBehaviour
{

    [Range(0.1f, 50)]
    public float moveSpeed = 8f;

    [Range(0.01f, 50)]
    public float sense = 1f;

    private new Camera camera;

    public float zoomedFOV = 25f;
    private float standardFOV;


    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        camera = GetComponent<Camera>();
        standardFOV = camera.fieldOfView;
    }
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(1))
            camera.fieldOfView = zoomedFOV;
        if (Input.GetMouseButtonUp(1))
            camera.fieldOfView = standardFOV;

        transform.position += transform.forward *
            moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        transform.position += transform.right *
            moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 5, Space.Self);
        transform.Rotate(Vector3.right * -Input.GetAxis("Mouse Y") * 5, Space.Self);
	}
}
