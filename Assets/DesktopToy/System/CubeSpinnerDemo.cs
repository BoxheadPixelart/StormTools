using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpinnerDemo : MonoBehaviour
{
    // Start is called before the first frame update
    float x; 
    float y; 
    float z; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x += Time.deltaTime / 2f; 
        y += Time.deltaTime / 2f; 
        z -= Time.deltaTime / 2f;
        transform.rotation = Quaternion.Euler(x, y, z); 
    }
    
}
