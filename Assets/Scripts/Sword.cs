using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform Swordpoint;
    public Transform a, b, c;
    public LayerMask sliceableLayer;

    SliceableMesh sm;

    private void OnTriggerEnter(Collider other)
    {
        b.position = Swordpoint.position;
    }
    private void OnTriggerExit(Collider other)
    {
        c.position = Swordpoint.position;

        if (other.gameObject.layer != 6) return;

        other.TryGetComponent(out SliceableMesh sm);
        if (sm != null)
        {
            sm.Slice(a.position, b.position, c.position);
        }
    }
}
