using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBodyMatcher : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform goalTransform;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScaleUpdate()); 
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(goalTransform.position.x,goalTransform.position.y - 1f,goalTransform.position.z); 
        target.position = pos;
        target.rotation = goalTransform.rotation; 
    }
    IEnumerator ScaleUpdate()
    {
        yield return new WaitForSeconds(0.1f);
        transform.localScale = transform.localScale * 100;
    }
}
