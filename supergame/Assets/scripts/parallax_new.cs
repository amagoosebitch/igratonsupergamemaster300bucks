using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax_new : MonoBehaviour
{
    public float Parallax;
    public GameObject cam;
    private float startPosX;
    void Start()
    {
        startPosX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distX = (cam.transform.position.x * (1 - Parallax));
        transform.position = new Vector3(startPosX + distX, transform.position.y, transform.position.z);
    }
}
