using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPositioner : MonoBehaviour
{
    private float defaultPosZ;
    private Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        defaultPosZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance > defaultPosZ)
            {
                transform.localPosition = new Vector3(0, 0, hit.distance * 0.95f);
            }
            else
            {
                transform.localPosition = new Vector3(0, 0, defaultPosZ);
            }
        }
    }
}
