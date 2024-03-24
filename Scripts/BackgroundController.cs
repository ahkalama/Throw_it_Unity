using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(waitingcolor());
        
    }

    IEnumerator waitingcolor()
    {
        while (true)
        {
            Color newColor = new Color(Random.value, Random.value, Random.value);
            Renderer renderer = GetComponent<Renderer>();
            if (renderer)
            {
                renderer.material.color = newColor;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
