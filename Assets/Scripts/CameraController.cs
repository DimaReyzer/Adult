using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 lookAt;
    public BoxCollider2D viewBox;
    public float sensitivity;

    void OnEnable(){
        lookAt.z = transform.position.z;
    }
    void Update(){
        MoveCameraByMouse();
    }

    void MoveCameraByMouse(){
        float xMouse = Input.mousePosition.x;
        float yMouse = Input.mousePosition.y;
        if(xMouse < 10){
            lookAt.x -= sensitivity * Time.deltaTime;
        }else if(xMouse > Screen.width - 10){
            lookAt.x += sensitivity * Time.deltaTime;
        }
        
        if(yMouse < 10){
            lookAt.y -= sensitivity * Time.deltaTime;
        }else if(yMouse > Screen.height - 10){
            lookAt.y += sensitivity * Time.deltaTime;
        }
        lookAt.x = Mathf.Clamp(lookAt.x,viewBox.bounds.min.x,viewBox.bounds.max.x);
        lookAt.y = Mathf.Clamp(lookAt.y,viewBox.bounds.min.y,viewBox.bounds.max.y);
        transform.position = Vector3.Lerp(transform.position,lookAt,0.25f);
    }
}
