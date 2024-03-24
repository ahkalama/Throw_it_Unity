using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField] private float donushizi;

    void Update()
    {
        RotateCirle();
    }

    void RotateCirle()
    {
        transform.Rotate(Vector3.forward * donushizi * Time.deltaTime);
    }
}
