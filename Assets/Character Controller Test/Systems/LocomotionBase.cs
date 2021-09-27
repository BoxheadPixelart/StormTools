using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Storm.CharacterController;

namespace Storm.CharacterController
{


    public class LocomotionBase : MonoBehaviour
    {
        [SerializeField] MoverBase mover;

        // Start is called before the first frame update
        void Start()
        {
            mover = GetComponent<MoverBase>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
