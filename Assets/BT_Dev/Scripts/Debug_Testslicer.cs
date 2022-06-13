using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Testslicer : MonoBehaviour
{
    public Transform a, b, c;
    public KeyCode sliceKey;
    public LayerMask sliceableLayer;

    SliceableMesh sm;

    private void Update()
    {
        if(Input.GetKeyDown(sliceKey))
        {
            var col = Physics.OverlapBox(transform.position, new Vector3(100f, 00.1f, 100f), Quaternion.identity, sliceableLayer);

            col[0].TryGetComponent(out SliceableMesh sm);
            
            if(sm != null)
            {
                sm.Slice(a.position, b.position, c.position);
            }
        }
    }

}
