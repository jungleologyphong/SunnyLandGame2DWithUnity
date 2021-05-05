using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSunny : MonoBehaviour
{
    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;
    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
    public GameObject sunny;
    void Start()
    {
        sunny = GameObject.FindGameObjectWithTag("Sunny");
    }

    void FixedUpdate()
    {
        float positionX = Mathf.SmoothDamp(transform.position.x, sunny.transform.position.x, ref velocity.x, smoothTimeX);
        float positionY = Mathf.SmoothDamp(transform.position.y, sunny.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(positionX,positionY,transform.position.z); 

        if(bounds){
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                                             Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                                             Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }
}
