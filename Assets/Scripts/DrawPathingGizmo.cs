using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPathingGizmo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //https://learn.unity.com/tutorial/creating-custom-gizmos-for-development-2019-2#5e467a7cedbc2a0021dccf66

    #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "Art/T_PathingGizmo.png", true);
        }
    #endif

}
