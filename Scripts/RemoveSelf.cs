using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSelf : MonoBehaviour
{
    public bool checkOutOfBounds = true;
    public Vector3 minBounds = Vector3.negativeInfinity;
    public Vector3 maxBounds = Vector3.positiveInfinity;
    private ShooterBallGame sbg;

    public bool checkTimeout = true;
    public float timeOut = 5f;
    private float timer;

    private void Start()
    {
        sbg = FindObjectOfType<ShooterBallGame>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (checkOutOfBounds)
        {
            Vector3 pos = transform.position;
            if (pos.x < minBounds.x || pos.x > maxBounds.x ||
                pos.y < minBounds.y || pos.y > maxBounds.y ||
                pos.z < minBounds.z || pos.z > maxBounds.z)
            {
                Remove();
            }
        }

        if (checkTimeout && Time.time > timer)
        {
            Remove();
            sbg.scoreInt--;
        }
    }

    private void Remove()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (checkTimeout)
        {
            timer = Time.time + timeOut;
        }
    }
}
