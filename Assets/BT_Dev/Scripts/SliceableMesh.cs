using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class SliceableMesh : MonoBehaviour
{
    [SerializeField]
    private Color CutplaneColor;
    [SerializeField]
    private int Slicelimit = 5;
    private MeshFilter meshF;

    private int slicecount = 0;

    private void Awake()
    {
        meshF = GetComponent<MeshFilter>();
    }

    //private enum TrisCond { Error, Down, ItscUp,ItscDown,Up }

    bool breaksig = false;

    //public void DevideMesh(Vector3 a, Vector3 b, Vector3 c)
    //{
    //    Plane plane = new Plane();

    //    a = transform.InverseTransformPoint(a);
    //    b = transform.InverseTransformPoint(b);
    //    c = transform.InverseTransformPoint(c);

    //    plane.SetNormalAndPosition(Vector3.Cross(b - a, c - a), a);
    //    Mesh m = meshF.mesh;

    //    if (plane.GetSide(m.vertices[0]))
    //    {
    //        for (int i = 0; i < m.vertices.Length; i++)
    //        {
    //            if (plane.GetSide(m.vertices[i])) { }
    //            if (i > m.vertices.Length - 1) return;
    //        }
    //    }
    //    if (!plane.GetSide(m.vertices[0]))
    //    {
    //        for (int i = 0; i < m.vertices.Length; i++)
    //        {
    //            if (!plane.GetSide(m.vertices[i])) { }
    //            if (i > m.vertices.Length - 1) return;
    //        }
    //    }

    //    List<Vector3> vertsUp = new List<Vector3>();
    //    List<Vector3> vertsDown = new List<Vector3>();

    //    List<Vector2> uvsUp = new List<Vector2>();
    //    List<Vector2> uvsDown = new List<Vector2>();

    //    List<Vector3> normsUp = new List<Vector3>();
    //    List<Vector3> normsDown = new List<Vector3>();

    //    List<int> trisUp = new List<int>();
    //    List<int> trisDown = new List<int>();

    //    for (int i = 0; i < m.triangles.Length - 3; i += 3)
    //    {
    //        Vector3 poA = m.vertices[m.triangles[i]]; Vector2 uvA = m.uv[m.triangles[i]]; Vector3 normA = m.normals[m.triangles[i]];
    //        Vector3 poB = m.vertices[m.triangles[i + 1]]; Vector3 uvB = m.uv[m.triangles[i + 1]]; Vector3 normB = m.normals[m.triangles[i + 1]];
    //        Vector3 poC = m.vertices[m.triangles[i + 2]]; Vector3 uvC = m.uv[m.triangles[i + 2]]; Vector3 normC = m.normals[m.triangles[i + 2]];

    //        switch (TrisIntersectCondition(new Vector3[] { poA, poB, poC }, plane))
    //        {
    //            case TrisCond.Up:

    //                break;
    //            case TrisCond.Down:
    //                break;
    //            case TrisCond.ItscUp:
    //                break;
    //            case TrisCond.ItscDown:
    //                break;

    //        }

    //    }
    //    {
    //    //    for (int i = 0; i < m.vertices.Length - 3; i = i + 3)
    //    //    {

    //    //        {
    //    //            var poA = m.vertices[i];
    //    //            var poB = m.vertices[i + 1];
    //    //            var poC = m.vertices[i + 2];

    //    //            var uvA = m.uv[i];
    //    //            var uvB = m.uv[i + 1];
    //    //            var uvC = m.uv[i + 2];

    //    //            var normA = m.normals[i];
    //    //            var normB = m.normals[i + 1];
    //    //            var normC = m.normals[i + 2];

    //    //            List<Vector3> intersecPoints = new List<Vector3>();

    //    //            Vector3 itsc1, itsc2;
    //    //            Vector2 uv_itsc1, uv_itsc2;




    //    //            if (plane.GetSide(poA) && plane.GetSide(poB) && plane.GetSide(poC))
    //    //            {
    //    //                vertsUp.Add(poA); uvsUp.Add(m.uv[i]); normsUp.Add(m.normals[i]);
    //    //                vertsUp.Add(poB); uvsUp.Add(m.uv[i + 1]); normsUp.Add(m.normals[i + 1]);
    //    //                vertsUp.Add(poC); uvsUp.Add(m.uv[i + 2]); normsUp.Add(m.normals[i + 2]);
    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount+1); trisUp.Add(upVertsCount + 2);
    //    //                //upVertsCount += 3;
    //    //            }
    //    //            else if (!plane.GetSide(poA) && !plane.GetSide(poB) && !plane.GetSide(poC))
    //    //            {
    //    //                vertsDown.Add(poA); uvsDown.Add(m.uv[i]); normsDown.Add(m.normals[i]);
    //    //                vertsDown.Add(poB); uvsDown.Add(m.uv[i + 1]); normsDown.Add(m.normals[i + 1]);
    //    //                vertsDown.Add(poC); uvsDown.Add(m.uv[i + 2]); normsDown.Add(m.normals[i + 2]);
    //    //                //trisDown.Add(downVertsCount); trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 2);
    //    //                //downVertsCount += 3;
    //    //            }
    //    //            else if (plane.GetSide(poA) && !plane.GetSide(poB) && !plane.GetSide(poC))
    //    //            {
    //    //                itsc1 = GetIntsectionVecToPlane(poA, poB, a, plane.normal);
    //    //                itsc2 = GetIntsectionVecToPlane(poA, poC, a, plane.normal);

    //    //                uv_itsc1 = GetItscPointUV(uvA, uvB, poA, poB, itsc1);
    //    //                uv_itsc2 = GetItscPointUV(uvA, uvC, poA, poC, itsc2);

    //    //                vertsUp.Add(poA); uvsUp.Add(uvA); normsUp.Add(normA);
    //    //                vertsUp.Add(itsc2); uvsUp.Add(uv_itsc2); normsUp.Add(normA);
    //    //                vertsUp.Add(itsc1); uvsUp.Add(uv_itsc1); normsUp.Add(normA);

    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 1); trisUp.Add(upVertsCount + 2);
    //    //                //upVertsCount += 3;

    //    //                vertsDown.Add(itsc1); uvsDown.Add(uv_itsc1); normsDown.Add(normB);
    //    //                vertsDown.Add(itsc2); uvsDown.Add(uv_itsc2); normsDown.Add(normC);
    //    //                vertsDown.Add(poB); uvsDown.Add(uvB); normsDown.Add(normB);
    //    //                vertsDown.Add(poC); uvsDown.Add(uvC); normsDown.Add(normC);

    //    //                //trisDown.Add(downVertsCount); trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 2);
    //    //                //trisDown.Add(downVertsCount + 2); trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 3);
    //    //                //downVertsCount += 4;


    //    //            }
    //    //            else if (plane.GetSide(poB) && !plane.GetSide(poA) && !plane.GetSide(poC))
    //    //            {
    //    //                itsc1 = GetIntsectionVecToPlane(poB, poA, a, plane.normal);
    //    //                itsc2 = GetIntsectionVecToPlane(poB, poC, a, plane.normal);

    //    //                uv_itsc1 = GetItscPointUV(uvB, uvA, poB, poA, itsc1);
    //    //                uv_itsc2 = GetItscPointUV(uvB, uvC, poB, poC, itsc2);

    //    //                vertsUp.Add(poB); uvsUp.Add(uvB); normsUp.Add(normB);
    //    //                vertsUp.Add(itsc2); uvsUp.Add(uv_itsc2); normsUp.Add(normA);
    //    //                vertsUp.Add(itsc1); uvsUp.Add(uv_itsc1); normsUp.Add(normA);

    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 1); trisUp.Add(upVertsCount + 2);
    //    //                //upVertsCount += 3;

    //    //                vertsDown.Add(itsc1); uvsDown.Add(uv_itsc1); normsDown.Add(normA);
    //    //                vertsDown.Add(itsc2); uvsDown.Add(uv_itsc2); normsDown.Add(normC);
    //    //                vertsDown.Add(poA); uvsDown.Add(uvA); normsDown.Add(normA);
    //    //                vertsDown.Add(poC); uvsDown.Add(uvC); normsDown.Add(normC);

    //    //                //trisDown.Add(downVertsCount); trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 2);
    //    //                //trisDown.Add(downVertsCount + 2); trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 3);
    //    //                //downVertsCount += 4;
    //    //            }
    //    //            else if (plane.GetSide(poC) && !plane.GetSide(poB) && !plane.GetSide(poA))
    //    //            {
    //    //                itsc1 = GetIntsectionVecToPlane(poC, poA, a, plane.normal);
    //    //                itsc2 = GetIntsectionVecToPlane(poC, poB, a, plane.normal);

    //    //                uv_itsc1 = GetItscPointUV(uvC, uvA, poC, poA, itsc1);
    //    //                uv_itsc2 = GetItscPointUV(uvC, uvB, poC, poB, itsc2);

    //    //                vertsUp.Add(poC); uvsUp.Add(uvC); normsUp.Add(normC);
    //    //                vertsUp.Add(itsc2); uvsUp.Add(uv_itsc2); normsUp.Add(normA);
    //    //                vertsUp.Add(itsc1); uvsUp.Add(uv_itsc1); normsUp.Add(normA);
    //    //                //upVertsCount += 3;
    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 1); trisUp.Add(upVertsCount + 2);


    //    //                vertsDown.Add(itsc1); uvsDown.Add(uv_itsc1); normsDown.Add(normA);
    //    //                vertsDown.Add(itsc2); uvsDown.Add(uv_itsc2); normsDown.Add(normC);
    //    //                vertsDown.Add(poA); uvsDown.Add(uvA); normsDown.Add(normA);
    //    //                vertsDown.Add(poB); uvsDown.Add(uvB); normsDown.Add(normB);

    //    //                //trisDown.Add(downVertsCount); trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 2);
    //    //                //trisDown.Add(downVertsCount + 2); trisDown.Add(downVertsCount); trisDown.Add(downVertsCount + 3);
    //    //                //downVertsCount += 4;
    //    //            }
    //    //            else if (!plane.GetSide(poA) && plane.GetSide(poB) && plane.GetSide(poC))
    //    //            {
    //    //                itsc1 = GetIntsectionVecToPlane(poB, poA, a, plane.normal);
    //    //                itsc2 = GetIntsectionVecToPlane(poC, poA, a, plane.normal);

    //    //                uv_itsc1 = GetItscPointUV(uvB, uvA, poB, poA, itsc1);
    //    //                uv_itsc2 = GetItscPointUV(uvC, uvA, poC, poA, itsc2);

    //    //                vertsUp.Add(poB); uvsUp.Add(uvB); normsUp.Add(normB);
    //    //                vertsUp.Add(poC); uvsUp.Add(uvC); normsUp.Add(normC);
    //    //                vertsUp.Add(itsc1); uvsUp.Add(uv_itsc1); normsUp.Add(normA);
    //    //                vertsUp.Add(itsc2); uvsUp.Add(uv_itsc2); normsUp.Add(normA);

    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 3); trisUp.Add(upVertsCount + 2);
    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 1); trisUp.Add(upVertsCount + 3);
    //    //                //upVertsCount += 4;

    //    //                vertsDown.Add(poA); uvsDown.Add(uvA); normsDown.Add(normA);
    //    //                vertsDown.Add(itsc1); uvsDown.Add(uv_itsc1); normsDown.Add(normA);
    //    //                vertsDown.Add(itsc2); uvsDown.Add(uv_itsc2); normsDown.Add(normA);

    //    //                //trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 2); trisDown.Add(downVertsCount);
    //    //                //downVertsCount += 3;
    //    //            }
    //    //            else if (!plane.GetSide(poB) && plane.GetSide(poA) && plane.GetSide(poC))
    //    //            {
    //    //                itsc1 = GetIntsectionVecToPlane(poA, poB, a, plane.normal);
    //    //                itsc2 = GetIntsectionVecToPlane(poC, poB, a, plane.normal);

    //    //                uv_itsc1 = GetItscPointUV(uvA, uvB, poA, poB, itsc1);
    //    //                uv_itsc2 = GetItscPointUV(uvB, uvC, poB, poC, itsc2);

    //    //                vertsUp.Add(poA); uvsUp.Add(uvA); normsUp.Add(normA);
    //    //                vertsUp.Add(poC); uvsUp.Add(uvC); normsUp.Add(normC);
    //    //                vertsUp.Add(itsc1); uvsUp.Add(uv_itsc1); normsUp.Add(normB);
    //    //                vertsUp.Add(itsc2); uvsUp.Add(uv_itsc2); normsUp.Add(normB);

    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 3); trisUp.Add(upVertsCount + 2);
    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 1); trisUp.Add(upVertsCount + 3);
    //    //                //upVertsCount += 4;

    //    //                vertsDown.Add(poB); uvsDown.Add(uvB); normsDown.Add(normB);
    //    //                vertsDown.Add(itsc1); uvsDown.Add(uv_itsc1); normsDown.Add(normB);
    //    //                vertsDown.Add(itsc2); uvsDown.Add(uv_itsc2); normsDown.Add(normB);

    //    //                //trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 2); trisDown.Add(downVertsCount);
    //    //                //downVertsCount += 3;
    //    //            }
    //    //            else if (!plane.GetSide(poC) && plane.GetSide(poA) && plane.GetSide(poB))
    //    //            {
    //    //                itsc1 = GetIntsectionVecToPlane(poA, poC, a, plane.normal);
    //    //                itsc2 = GetIntsectionVecToPlane(poB, poC, a, plane.normal);

    //    //                uv_itsc1 = GetItscPointUV(uvA, uvC, poA, poC, itsc1);
    //    //                uv_itsc2 = GetItscPointUV(uvB, uvC, poB, poC, itsc2);

    //    //                vertsUp.Add(poA); uvsUp.Add(uvA); normsUp.Add(normA);
    //    //                vertsUp.Add(poB); uvsUp.Add(uvB); normsUp.Add(normB);
    //    //                vertsUp.Add(itsc1); uvsUp.Add(uv_itsc1); normsUp.Add(normC);
    //    //                vertsUp.Add(itsc2); uvsUp.Add(uv_itsc2); normsUp.Add(normC);

    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 3); trisUp.Add(upVertsCount + 2);
    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 1); trisUp.Add(upVertsCount + 3);
    //    //                //upVertsCount += 4;

    //    //                vertsDown.Add(poC); uvsDown.Add(uvC); normsDown.Add(normC);
    //    //                vertsDown.Add(itsc1); uvsDown.Add(uv_itsc1); normsDown.Add(normC);
    //    //                vertsDown.Add(itsc2); uvsDown.Add(uv_itsc2); normsDown.Add(normC);

    //    //                //trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 2); trisDown.Add(downVertsCount);
    //    //                //downVertsCount += 3;
    //    //            }
    //    //        }
    //    //    }
    //    //}        //{
    //    //    for (int i = 0; i < m.vertices.Length - 3; i = i + 3)
    //    //    {

    //    //        {
    //    //            var poA = m.vertices[i];
    //    //            var poB = m.vertices[i + 1];
    //    //            var poC = m.vertices[i + 2];

    //    //            var uvA = m.uv[i];
    //    //            var uvB = m.uv[i + 1];
    //    //            var uvC = m.uv[i + 2];

    //    //            var normA = m.normals[i];
    //    //            var normB = m.normals[i + 1];
    //    //            var normC = m.normals[i + 2];

    //    //            List<Vector3> intersecPoints = new List<Vector3>();

    //    //            Vector3 itsc1, itsc2;
    //    //            Vector2 uv_itsc1, uv_itsc2;




    //    //            if (plane.GetSide(poA) && plane.GetSide(poB) && plane.GetSide(poC))
    //    //            {
    //    //                vertsUp.Add(poA); uvsUp.Add(m.uv[i]); normsUp.Add(m.normals[i]);
    //    //                vertsUp.Add(poB); uvsUp.Add(m.uv[i + 1]); normsUp.Add(m.normals[i + 1]);
    //    //                vertsUp.Add(poC); uvsUp.Add(m.uv[i + 2]); normsUp.Add(m.normals[i + 2]);
    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount+1); trisUp.Add(upVertsCount + 2);
    //    //                //upVertsCount += 3;
    //    //            }
    //    //            else if (!plane.GetSide(poA) && !plane.GetSide(poB) && !plane.GetSide(poC))
    //    //            {
    //    //                vertsDown.Add(poA); uvsDown.Add(m.uv[i]); normsDown.Add(m.normals[i]);
    //    //                vertsDown.Add(poB); uvsDown.Add(m.uv[i + 1]); normsDown.Add(m.normals[i + 1]);
    //    //                vertsDown.Add(poC); uvsDown.Add(m.uv[i + 2]); normsDown.Add(m.normals[i + 2]);
    //    //                //trisDown.Add(downVertsCount); trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 2);
    //    //                //downVertsCount += 3;
    //    //            }
    //    //            else if (plane.GetSide(poA) && !plane.GetSide(poB) && !plane.GetSide(poC))
    //    //            {
    //    //                itsc1 = GetIntsectionVecToPlane(poA, poB, a, plane.normal);
    //    //                itsc2 = GetIntsectionVecToPlane(poA, poC, a, plane.normal);

    //    //                uv_itsc1 = GetItscPointUV(uvA, uvB, poA, poB, itsc1);
    //    //                uv_itsc2 = GetItscPointUV(uvA, uvC, poA, poC, itsc2);

    //    //                vertsUp.Add(poA); uvsUp.Add(uvA); normsUp.Add(normA);
    //    //                vertsUp.Add(itsc2); uvsUp.Add(uv_itsc2); normsUp.Add(normA);
    //    //                vertsUp.Add(itsc1); uvsUp.Add(uv_itsc1); normsUp.Add(normA);

    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 1); trisUp.Add(upVertsCount + 2);
    //    //                //upVertsCount += 3;

    //    //                vertsDown.Add(itsc1); uvsDown.Add(uv_itsc1); normsDown.Add(normB);
    //    //                vertsDown.Add(itsc2); uvsDown.Add(uv_itsc2); normsDown.Add(normC);
    //    //                vertsDown.Add(poB); uvsDown.Add(uvB); normsDown.Add(normB);
    //    //                vertsDown.Add(poC); uvsDown.Add(uvC); normsDown.Add(normC);

    //    //                //trisDown.Add(downVertsCount); trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 2);
    //    //                //trisDown.Add(downVertsCount + 2); trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 3);
    //    //                //downVertsCount += 4;


    //    //            }
    //    //            else if (plane.GetSide(poB) && !plane.GetSide(poA) && !plane.GetSide(poC))
    //    //            {
    //    //                itsc1 = GetIntsectionVecToPlane(poB, poA, a, plane.normal);
    //    //                itsc2 = GetIntsectionVecToPlane(poB, poC, a, plane.normal);

    //    //                uv_itsc1 = GetItscPointUV(uvB, uvA, poB, poA, itsc1);
    //    //                uv_itsc2 = GetItscPointUV(uvB, uvC, poB, poC, itsc2);

    //    //                vertsUp.Add(poB); uvsUp.Add(uvB); normsUp.Add(normB);
    //    //                vertsUp.Add(itsc2); uvsUp.Add(uv_itsc2); normsUp.Add(normA);
    //    //                vertsUp.Add(itsc1); uvsUp.Add(uv_itsc1); normsUp.Add(normA);

    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 1); trisUp.Add(upVertsCount + 2);
    //    //                //upVertsCount += 3;

    //    //                vertsDown.Add(itsc1); uvsDown.Add(uv_itsc1); normsDown.Add(normA);
    //    //                vertsDown.Add(itsc2); uvsDown.Add(uv_itsc2); normsDown.Add(normC);
    //    //                vertsDown.Add(poA); uvsDown.Add(uvA); normsDown.Add(normA);
    //    //                vertsDown.Add(poC); uvsDown.Add(uvC); normsDown.Add(normC);

    //    //                //trisDown.Add(downVertsCount); trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 2);
    //    //                //trisDown.Add(downVertsCount + 2); trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 3);
    //    //                //downVertsCount += 4;
    //    //            }
    //    //            else if (plane.GetSide(poC) && !plane.GetSide(poB) && !plane.GetSide(poA))
    //    //            {
    //    //                itsc1 = GetIntsectionVecToPlane(poC, poA, a, plane.normal);
    //    //                itsc2 = GetIntsectionVecToPlane(poC, poB, a, plane.normal);

    //    //                uv_itsc1 = GetItscPointUV(uvC, uvA, poC, poA, itsc1);
    //    //                uv_itsc2 = GetItscPointUV(uvC, uvB, poC, poB, itsc2);

    //    //                vertsUp.Add(poC); uvsUp.Add(uvC); normsUp.Add(normC);
    //    //                vertsUp.Add(itsc2); uvsUp.Add(uv_itsc2); normsUp.Add(normA);
    //    //                vertsUp.Add(itsc1); uvsUp.Add(uv_itsc1); normsUp.Add(normA);
    //    //                //upVertsCount += 3;
    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 1); trisUp.Add(upVertsCount + 2);


    //    //                vertsDown.Add(itsc1); uvsDown.Add(uv_itsc1); normsDown.Add(normA);
    //    //                vertsDown.Add(itsc2); uvsDown.Add(uv_itsc2); normsDown.Add(normC);
    //    //                vertsDown.Add(poA); uvsDown.Add(uvA); normsDown.Add(normA);
    //    //                vertsDown.Add(poB); uvsDown.Add(uvB); normsDown.Add(normB);

    //    //                //trisDown.Add(downVertsCount); trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 2);
    //    //                //trisDown.Add(downVertsCount + 2); trisDown.Add(downVertsCount); trisDown.Add(downVertsCount + 3);
    //    //                //downVertsCount += 4;
    //    //            }
    //    //            else if (!plane.GetSide(poA) && plane.GetSide(poB) && plane.GetSide(poC))
    //    //            {
    //    //                itsc1 = GetIntsectionVecToPlane(poB, poA, a, plane.normal);
    //    //                itsc2 = GetIntsectionVecToPlane(poC, poA, a, plane.normal);

    //    //                uv_itsc1 = GetItscPointUV(uvB, uvA, poB, poA, itsc1);
    //    //                uv_itsc2 = GetItscPointUV(uvC, uvA, poC, poA, itsc2);

    //    //                vertsUp.Add(poB); uvsUp.Add(uvB); normsUp.Add(normB);
    //    //                vertsUp.Add(poC); uvsUp.Add(uvC); normsUp.Add(normC);
    //    //                vertsUp.Add(itsc1); uvsUp.Add(uv_itsc1); normsUp.Add(normA);
    //    //                vertsUp.Add(itsc2); uvsUp.Add(uv_itsc2); normsUp.Add(normA);

    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 3); trisUp.Add(upVertsCount + 2);
    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 1); trisUp.Add(upVertsCount + 3);
    //    //                //upVertsCount += 4;

    //    //                vertsDown.Add(poA); uvsDown.Add(uvA); normsDown.Add(normA);
    //    //                vertsDown.Add(itsc1); uvsDown.Add(uv_itsc1); normsDown.Add(normA);
    //    //                vertsDown.Add(itsc2); uvsDown.Add(uv_itsc2); normsDown.Add(normA);

    //    //                //trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 2); trisDown.Add(downVertsCount);
    //    //                //downVertsCount += 3;
    //    //            }
    //    //            else if (!plane.GetSide(poB) && plane.GetSide(poA) && plane.GetSide(poC))
    //    //            {
    //    //                itsc1 = GetIntsectionVecToPlane(poA, poB, a, plane.normal);
    //    //                itsc2 = GetIntsectionVecToPlane(poC, poB, a, plane.normal);

    //    //                uv_itsc1 = GetItscPointUV(uvA, uvB, poA, poB, itsc1);
    //    //                uv_itsc2 = GetItscPointUV(uvB, uvC, poB, poC, itsc2);

    //    //                vertsUp.Add(poA); uvsUp.Add(uvA); normsUp.Add(normA);
    //    //                vertsUp.Add(poC); uvsUp.Add(uvC); normsUp.Add(normC);
    //    //                vertsUp.Add(itsc1); uvsUp.Add(uv_itsc1); normsUp.Add(normB);
    //    //                vertsUp.Add(itsc2); uvsUp.Add(uv_itsc2); normsUp.Add(normB);

    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 3); trisUp.Add(upVertsCount + 2);
    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 1); trisUp.Add(upVertsCount + 3);
    //    //                //upVertsCount += 4;

    //    //                vertsDown.Add(poB); uvsDown.Add(uvB); normsDown.Add(normB);
    //    //                vertsDown.Add(itsc1); uvsDown.Add(uv_itsc1); normsDown.Add(normB);
    //    //                vertsDown.Add(itsc2); uvsDown.Add(uv_itsc2); normsDown.Add(normB);

    //    //                //trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 2); trisDown.Add(downVertsCount);
    //    //                //downVertsCount += 3;
    //    //            }
    //    //            else if (!plane.GetSide(poC) && plane.GetSide(poA) && plane.GetSide(poB))
    //    //            {
    //    //                itsc1 = GetIntsectionVecToPlane(poA, poC, a, plane.normal);
    //    //                itsc2 = GetIntsectionVecToPlane(poB, poC, a, plane.normal);

    //    //                uv_itsc1 = GetItscPointUV(uvA, uvC, poA, poC, itsc1);
    //    //                uv_itsc2 = GetItscPointUV(uvB, uvC, poB, poC, itsc2);

    //    //                vertsUp.Add(poA); uvsUp.Add(uvA); normsUp.Add(normA);
    //    //                vertsUp.Add(poB); uvsUp.Add(uvB); normsUp.Add(normB);
    //    //                vertsUp.Add(itsc1); uvsUp.Add(uv_itsc1); normsUp.Add(normC);
    //    //                vertsUp.Add(itsc2); uvsUp.Add(uv_itsc2); normsUp.Add(normC);

    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 3); trisUp.Add(upVertsCount + 2);
    //    //                //trisUp.Add(upVertsCount); trisUp.Add(upVertsCount + 1); trisUp.Add(upVertsCount + 3);
    //    //                //upVertsCount += 4;

    //    //                vertsDown.Add(poC); uvsDown.Add(uvC); normsDown.Add(normC);
    //    //                vertsDown.Add(itsc1); uvsDown.Add(uv_itsc1); normsDown.Add(normC);
    //    //                vertsDown.Add(itsc2); uvsDown.Add(uv_itsc2); normsDown.Add(normC);

    //    //                //trisDown.Add(downVertsCount + 1); trisDown.Add(downVertsCount + 2); trisDown.Add(downVertsCount);
    //    //                //downVertsCount += 3;
    //    //            }
    //    //        }
    //    //    }
    //    }



    //    for(int k = 0; k < vertsDown.Count; k++)
    //    {
    //        Debug.DrawLine(vertsDown[0], vertsDown[0] + Vector3.down, Color.magenta,100000f);
    //    }

    //    Mesh upMesh = new Mesh();
    //    upMesh.vertices = vertsUp.ToArray();
    //    upMesh.uv = uvsUp.ToArray();
    //    upMesh.normals = normsUp.ToArray();
    //    upMesh.triangles = trisUp.ToArray();

    //    for (int k = 0; k < upMesh.vertexCount; k++)
    //    {
    //        Debug.DrawLine(transform.localToWorldMatrix.MultiplyPoint3x4(upMesh.vertices[k]), transform.localToWorldMatrix.MultiplyPoint3x4(upMesh.vertices[k] + upMesh.normals[k]*0.1f), Color.magenta, 10000f);
    //    }

    //    meshF.mesh = upMesh;
    //    meshF.gameObject.GetComponent<MeshCollider>().sharedMesh = upMesh;
    //    meshF.mesh.RecalculateBounds();

    //    Mesh downMesh = new Mesh();
    //    downMesh.vertices = vertsDown.ToArray();
    //    downMesh.uv = uvsDown.ToArray();
    //    downMesh.normals = normsDown.ToArray();
    //    downMesh.triangles = trisDown.ToArray();

    //    for (int k = 0; k < upMesh.vertexCount; k++)
    //    {
    //        Debug.DrawLine(transform.localToWorldMatrix.MultiplyPoint3x4(downMesh.vertices[k]), transform.localToWorldMatrix.MultiplyPoint3x4(downMesh.vertices[k] + downMesh.normals[k]*0.1f), Color.green, 10000f);
    //    }

    //    var bottomObj = Instantiate(gameObject, transform.position, Quaternion.identity);
    //    bottomObj.GetComponent<MeshFilter>().mesh = downMesh;
    //    bottomObj.GetComponent<MeshCollider>().sharedMesh = downMesh;
    //    bottomObj.GetComponent<MeshFilter>().mesh.RecalculateBounds();
    //}

    struct Triangle
    {
        public Vector3 v1;
        public Vector3 v2;
        public Vector3 v3;

        public Vector2 uv1;
        public Vector2 uv2;
        public Vector2 uv3;

        public Vector3 getNormal()
        {
            return Vector3.Cross(v1 - v2, v1 - v3).normalized;
        }

        // Conver direction to point in the direction of the tri
        public void matchDirection(Vector3 dir)
        {
            if (Vector3.Dot(getNormal(), dir) > 0)
            {
                return;
            }
            else
            {
                Vector3 vec = v1;
                Vector2 u = uv1;
                v1 = v3;
               uv1 = uv3;
                v3 = vec;
               uv3 = u;
            }
        }
    }

    public void Slice(Vector3 sliceIn, Vector3 sliceOut, Vector3 SwordOrigin)
    {
        if (slicecount >= Slicelimit) return;
        else slicecount++;

        Debug.Log("pre mesh uv count : " + meshF.mesh.uv.Length);
        Debug.Log("pre mesh vert count : " + meshF.mesh.vertices.Length);

        Plane pl = new Plane();
        pl.Set3Points(transform.worldToLocalMatrix.MultiplyPoint3x4(sliceIn),transform.worldToLocalMatrix.MultiplyPoint3x4(sliceOut), transform.worldToLocalMatrix.MultiplyPoint3x4(SwordOrigin));
        Mesh m = meshF.mesh;
        int[] triangles = m.triangles;
        Vector3[] verts = m.vertices;
        Vector2[] meshUvs = meshF.sharedMesh.uv;

        Vector3 scale = transform.lossyScale;

        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        List<Vector3> intersections = new List<Vector3>();
        List<Vector2> itscUvs = new List<Vector2>();
        List<Triangle> newTris1 = new List<Triangle>();
        List<Triangle> newTris2 = new List<Triangle>();

        // Loop through tris
        for (int i = 0; i < triangles.Length; i += 3)
        {
            List<Vector3> points = new List<Vector3>();
            List<Vector2> current_uvs = new List<Vector2>();

            int v1 = triangles[i];
            int v2 = triangles[i + 1];
            int v3 = triangles[i + 2];
            Vector3 p1 = verts[v1];
            Vector3 p2 = verts[v2];
            Vector3 p3 = verts[v3];
            Vector2 u1 = meshUvs[v1];
            Vector2 u2 = meshUvs[v2];
            Vector2 u3 = meshUvs[v3];
            Vector3 norm = Vector3.Cross(p1 - p2, p1 - p3);

            Vector3 dir = p2 - p1;
            float ent;

            // Check if tris are intersected
            if (pl.Raycast(new Ray(p1, dir), out ent) && ent <= dir.magnitude)
            {
                Vector3 intersection = p1 + ent * dir.normalized;
                intersections.Add(intersection);
                points.Add(intersection);
                var iu = GetItscPointUV(u1, u2, p1, p2, intersection);
                itscUvs.Add(iu);
                current_uvs.Add(iu);
            }
            dir = p3 - p2;
            if (pl.Raycast(new Ray(p2, dir), out ent) && ent <= dir.magnitude)
            {
                Vector3 intersection = p2 + ent * dir.normalized;
                intersections.Add(intersection);
                points.Add(intersection);
                var iu = GetItscPointUV(u2, u3, p2, p3, intersection);
                itscUvs.Add(iu);
                current_uvs.Add(iu);
            }
            dir = p3 - p1;
            if (pl.Raycast(new Ray(p1, dir), out ent) && ent <= dir.magnitude)
            {
                Vector3 intersection = p1 + ent * dir.normalized;
                intersections.Add(intersection);
                points.Add(intersection);
                var iu = GetItscPointUV(u1, u3, p1, p3, intersection);
                itscUvs.Add(iu);
                current_uvs.Add(iu);
            }

            // Group tris and create new tris
            if (points.Count > 0)
            {
                Debug.Assert(points.Count == 2);
                List<Vector3> points1 = new List<Vector3>();
                List<Vector3> points2 = new List<Vector3>();
                List<Vector2> uvs1 = new List<Vector2>();
                List<Vector2> uvs2 = new List<Vector2>();
                points1.AddRange(points);
                points2.AddRange(points);
                uvs1.AddRange(current_uvs);
                uvs2.AddRange(current_uvs);
                if (pl.GetSide(p1))
                {
                    points1.Add(p1);
                    uvs1.Add(u1);
                }
                else
                {
                    points2.Add(p1);
                    uvs2.Add(u1);
                }
                if (pl.GetSide(p2))
                {
                    points1.Add(p2);
                    uvs1.Add(u2);
                }
                else
                {
                    points2.Add(p2);
                    uvs2.Add(u2);
                }
                if (pl.GetSide(p3))
                {
                    points1.Add(p3);
                    uvs1.Add(u3);
                }
                else
                {
                    points2.Add(p3);
                    uvs2.Add(u3);
                }

                if (points1.Count == 3)
                {
                    Triangle tri = new Triangle() { v1 = points1[1], v2 = points1[0], v3 = points1[2], uv1 = uvs1[1], uv2 = uvs1[0], uv3 = uvs1[2] };
                    tri.matchDirection(norm);
                    newTris1.Add(tri);
                }
                else
                {
                    Debug.Assert(points1.Count == 4);
                    if (Vector3.Dot((points1[0] - points1[1]), points1[2] - points1[3]) >= 0)
                    {
                        Triangle tri = new Triangle() { v1 = points1[0], v2 = points1[2], v3 = points1[3], uv1 = uvs1[0], uv2 = uvs1[2], uv3 =uvs1[3] };
                        tri.matchDirection(norm);
                        newTris1.Add(tri);

                        tri = new Triangle() { v1 = points1[0], v2 = points1[3], v3 = points1[1], uv1 = uvs1[0], uv2 = uvs1[3], uv3 = uvs1[1] };
                        tri.matchDirection(norm);
                        newTris1.Add(tri);
                    }
                    else
                    {
                        Triangle tri = new Triangle() { v1 = points1[0], v2 = points1[3], v3 = points1[2], uv1 = uvs1[0], uv2 = uvs1[3], uv3 = uvs1[2] };
                        tri.matchDirection(norm);
                        newTris1.Add(tri);

                        tri = new Triangle() { v1 = points1[0], v2 = points1[2], v3 = points1[1], uv1 = uvs1[0], uv2 = uvs1[2], uv3 = uvs1[1] };
                        tri.matchDirection(norm);
                        newTris1.Add(tri);
                    }
                }

                if (points2.Count == 3)
                {
                    Triangle tri = new Triangle() { v1 = points2[1], v2 = points2[0], v3 = points2[2], uv1 = uvs2[1], uv2 = uvs2[0], uv3 = uvs2[2] };
                    tri.matchDirection(norm);
                    newTris2.Add(tri);
                }
                else
                {
                    Debug.Assert(points2.Count == 4);
                    if (Vector3.Dot((points2[0] - points2[1]), points2[2] - points2[3]) >= 0)
                    {
                        Triangle tri = new Triangle() { v1 = points2[0], v2 = points2[2], v3 = points2[3], uv1 = uvs2[0], uv2 = uvs2[2], uv3 = uvs2[3] };
                        tri.matchDirection(norm);
                        newTris2.Add(tri);

                        tri = new Triangle() { v1 = points2[0], v2 = points2[3], v3 = points2[1], uv1 = uvs2[0], uv2 = uvs2[3], uv3 = uvs2[1] };
                        tri.matchDirection(norm);
                        newTris2.Add(tri);
                    }
                    else
                    {
                        Triangle tri = new Triangle() { v1 = points2[0], v2 = points2[3], v3 = points2[2], uv1 = uvs2[0], uv2 = uvs2[3], uv3 = uvs2[2] };
                        tri.matchDirection(norm);
                        newTris2.Add(tri);

                        tri = new Triangle() { v1 = points2[0], v2 = points2[2], v3 = points2[1], uv1 = uvs2[0], uv2 = uvs2[2], uv3 = uvs2[1] };
                        tri.matchDirection(norm);
                        newTris2.Add(tri);
                    }
                }
            }
            else
            {
                if (pl.GetSide(p1))
                {
                    newTris1.Add(new Triangle() { v1 = p1, v2 = p2, v3 = p3 ,uv1 = u1, uv2 = u2, uv3 = u3 });
                }
                else
                {
                    newTris2.Add(new Triangle() { v1 = p1, v2 = p2, v3 = p3, uv1 = u1, uv2 = u2, uv3 = u3 });
                }
            }
        }

        if (intersections.Count > 1)
        {
            Vector3 center = Vector3.zero;
            foreach (Vector3 vec in intersections)
            {
                center += vec;
            }
            center /= intersections.Count;


            for (int i = 0; i < intersections.Count; i++)
            {
                Triangle tri = new Triangle() { v1 = intersections[i], v2 = center, v3 = i + 1 == intersections.Count ? intersections[i] : intersections[i + 1] };
                tri.matchDirection(-pl.normal);
                newTris1.Add(tri);
            }
            for (int i = 0; i < intersections.Count; i++)
            {
                Triangle tri = new Triangle() { v1 = intersections[i], v2 = center, v3 = i + 1 == intersections.Count ? intersections[i] : intersections[i + 1] };
                tri.matchDirection(pl.normal);
                newTris2.Add(tri);
            }
        }

        if (intersections.Count > 0)
        {
            // Creates new meshes
            Material mat = GetComponent<MeshRenderer>().material;

            Mesh mesh1 = new Mesh();
            Mesh mesh2 = new Mesh();

            List<Vector3> tris = new List<Vector3>();
            List<Vector2> SurfaceUvs = new List<Vector2>();
            List<int> indices = new List<int>();

            int index = 0;
            foreach (Triangle thing in newTris1)
            {
                tris.Add(thing.v1);
                tris.Add(thing.v2);
                tris.Add(thing.v3);
                SurfaceUvs.Add(thing.uv1);
                SurfaceUvs.Add(thing.uv2);
                SurfaceUvs.Add(thing.uv3);
                indices.Add(index++);
                indices.Add(index++);
                indices.Add(index++);
            }
            mesh1.vertices = tris.ToArray();
            mesh1.triangles = indices.ToArray();
            mesh1.uv = SurfaceUvs.ToArray();

            index = 0;
            tris.Clear();
            indices.Clear();
            SurfaceUvs.Clear();

            foreach (Triangle thing in newTris2)
            {
                tris.Add(thing.v1);
                tris.Add(thing.v2);
                tris.Add(thing.v3);
                SurfaceUvs.Add(thing.uv1);
                SurfaceUvs.Add(thing.uv2);
                SurfaceUvs.Add(thing.uv3);
                indices.Add(index++);
                indices.Add(index++);
                indices.Add(index++);
            }
            mesh2.vertices = tris.ToArray();
            mesh2.triangles = indices.ToArray();
            mesh2.uv = SurfaceUvs.ToArray();

            mesh1.RecalculateNormals();
            mesh1.RecalculateBounds();
            mesh2.RecalculateNormals();
            mesh2.RecalculateBounds();


            GameObject goNew = Instantiate(gameObject,transform.position,Quaternion.identity);

            transform.position = pos;
            meshF.mesh = mesh1;
            GetComponent<MeshCollider>().sharedMesh = mesh1;
            //GetComponent<MeshRenderer>().materials[1].color = CutplaneColor;

            goNew.transform.position = pos;
            goNew.transform.rotation = rot;
            goNew.GetComponent<MeshFilter>().mesh = mesh2;
            goNew.GetComponent<MeshCollider>().sharedMesh = mesh2;
            //goNew.GetComponent<MeshRenderer>().materials[1].color = CutplaneColor;

            Debug.Log("post mesh uv count : " + meshF.mesh.uv.Length);
            Debug.Log("post mesh vert count : " + meshF.mesh.vertices.Length);
        }
    }

    //private TrisCond TrisIntersectCondition(Vector3[] tri, Plane plane)
    //{
    //    int upCount = 0;
    //    if (plane.GetSide(tri[0])) upCount++;
    //    if (plane.GetSide(tri[1])) upCount++;
    //    if (plane.GetSide(tri[2])) upCount++;

    //    if (upCount == 3) return TrisCond.Up;
    //    else if (upCount == 2) return TrisCond.ItscDown;
    //    else if (upCount == 1) return TrisCond.ItscUp;
    //    else if (upCount == 0) return TrisCond.Down;
    //    else return TrisCond.Error;
    //}

    private Vector3 GetIntsectionVecToPlane(Vector3 a, Vector3 b, Vector3 planePoint, Vector3 planeNormal)
    {
        var abNormal = (b - a).normalized;

        return a + abNormal * Vector3.Dot(planeNormal,planePoint-a)/Vector3.Dot(planeNormal,abNormal);
    }

    private Vector2 GetItscPointUV(Vector2 uv_a, Vector2 uv_b, Vector3 pos_a, Vector3 pos_b, Vector3 pos_i)
    {
        return Vector2.Lerp(uv_a, uv_b, Vector3.Distance(pos_a, pos_i) / Vector3.Distance(pos_a, pos_b));
    }
}
