using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementTime;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;

    private Vector3 newPosition;

    private Engine engine;
    private PlayerStats player;
    // Start is called before the first frame update
    private void Start()
    {
        newPosition = transform.position;
        engine = FindObjectOfType<Engine>();
        player = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
       
        if(Input.GetKey(KeyCode.Mouse0))
        {
            
            if(Physics.Raycast(ray, out RaycastHit raycastHit, layerMask))
            {
                Vector3 mousePosition = raycastHit.point;
                mousePosition.y = 0;
                //Debug.Log(mousePosition);
                if(player.mainModules >= 7 && FindObjectOfType<Fight>().isFight == false) engine.Move(mousePosition);
            }
            
            
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            newPosition +=(transform.forward * -movementSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            newPosition += (transform.right * movementSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            newPosition += (transform.right * -movementSpeed);
        }

        transform.position = Vector3.Lerp((transform.position), newPosition, Time.deltaTime * movementTime);
    }
}
