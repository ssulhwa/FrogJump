using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject PlayerObject;

    Vector3 CameraVec;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CameraVec.z = PlayerObject.transform.position.z - 10f;
        CameraVec.x = PlayerObject.transform.position.x;
        transform.position = CameraVec;
        
        

        
    }
}
