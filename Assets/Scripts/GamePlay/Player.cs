using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Vector3 mouse_pos;
    public Transform target; //Assign to the object you want to rotate
    Vector3 object_pos;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * 6;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * 6;
/*
        Debug.Log("mouse position " + mouse_pos);
        Debug.Log("object position " + object_pos);
        Debug.Log("Vertical " + vertical + " Test " + Input.GetAxis("Vertical"));
        Debug.Log("Horizontal " + horizontal + " Test " +Input.GetAxis("Horizontal"));*/

        target.Translate(horizontal,vertical,0);
    }
}
