using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class cameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float mspeed=1.0f;
    public float rspeed=1.0f;
    // Update is called once per frame
    void Update()
    {
        
        Vector3 pos = GetComponent<Transform>().position;
        Quaternion rot = GetComponent<Transform>().rotation;
        if (Input.GetKey(KeyCode.A))
            pos.x -= mspeed*Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            pos.x += mspeed*Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
            pos.z += mspeed*Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            pos.z -=mspeed*Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
            pos.y +=mspeed*Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftControl))
            pos.y -=mspeed*Time.deltaTime;
        
        GetComponent<Transform>().position = pos;
        GetComponent<Transform>().rotation = rot;

        
        if (Input.GetKey(KeyCode.UpArrow))
            GetComponent<Transform>().Rotate(-Time.deltaTime*rspeed, 0.0f, 0.0f, Space.Self);

        if (Input.GetKey(KeyCode.DownArrow))
            GetComponent<Transform>().Rotate(Time.deltaTime*rspeed, 0.0f, 0.0f, Space.Self);
        
        
        if (Input.GetKey(KeyCode.LeftArrow))
            GetComponent<Transform>().Rotate(0.0f, -Time.deltaTime*rspeed, 0.0f, Space.Self);

        if (Input.GetKey(KeyCode.RightArrow))
            GetComponent<Transform>().Rotate(0.0f,Time.deltaTime*rspeed,  0.0f, Space.Self);


    }
}
