using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMove : MonoBehaviour{
    Camera cam;
    [SerializeField] float moveSpeed, rotSpeed;
    Vector3 vel;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update(){
        Vector3 newPos = Vector3.SmoothDamp(transform.position, transform.position + -transform.right, ref vel, moveSpeed);
        transform.position = new Vector3(newPos.x, newPos.y);

        Vector2 mouse = cam.ScreenToWorldPoint(Input.mousePosition);

        
        Quaternion rot = Quaternion.FromToRotation(Vector3.right, (transform.position - new Vector3(mouse.x,mouse.y)));
        
        
        transform.rotation = rot;
    }
}
