using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Storm.Utils; 

namespace Storm.Examples
{
    public class TestScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float[] SpringFloat = Numeric_Springing.Spring_Float(1, 1, 1, 0, 0, 0); 
        }
    }
}
