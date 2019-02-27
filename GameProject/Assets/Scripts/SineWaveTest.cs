
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class SineWaveTest : MonoBehaviour
{
    public int numCapVertices = 0;
    public int numCornerVertices = 0;
    public int lengthOfLine = 200;
    private LineRenderer lr;
    public float width = 1.0f;
    public bool useCurve = true;
    public float factor = .001f;
    public float offset = 10f;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));
    }

    void Update()
    {
        Vector3[] positions = new Vector3[lengthOfLine];
        lr.positionCount = positions.Length;
        /*
        while (i < lengthOfLine)
        {
            Vector3 pos = Vector3.zero;
            if (i < lengthOfLine-1)
                pos = new Vector3(i * factor, lr.GetPosition(i+1).y, 0);
            else
                pos = new Vector3(i * factor, Mathf.Sin(Time.time), 0);
            Debug.Log(pos);
            lr.SetPosition(i, pos);
            i++;
        }*/
        int i = 0;
        while (i < lengthOfLine)
        {
            Vector3 pos = new Vector3(i * factor, Mathf.PerlinNoise(0, i*factor + Time.time*offset), 0);
            lr.SetPosition(i, pos);
            Debug.Log(pos);
            i++;
        }

        lr.numCapVertices = numCapVertices;
        lr.numCornerVertices = numCornerVertices;
        AnimationCurve curve = new AnimationCurve();
        if (useCurve)
        {
            curve.AddKey(0.0f, 0.0f);
            curve.AddKey(1.0f, 1.0f);
        }
        else
        {
            curve.AddKey(0.0f, 1.0f);
            curve.AddKey(1.0f, 1.0f);
        }

        lr.widthCurve = curve;
        lr.widthMultiplier = width;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(25, 20, 200, 30), "Num Cap Vertices");
        numCapVertices = (int)GUI.HorizontalSlider(new Rect(165, 25, 200, 30), (float)numCapVertices, 0.0f, 20.0f);

        GUI.Label(new Rect(25, 60, 200, 30), "Num Corner Vertices");
        numCornerVertices = (int)GUI.HorizontalSlider(new Rect(165, 65, 200, 30), (float)numCornerVertices, 0.0f, 20.0f);

        GUI.Label(new Rect(25, 100, 200, 30), "Width");
        width = GUI.HorizontalSlider(new Rect(125, 105, 200, 30), width, 0.1f, 1.0f);
        useCurve = GUI.Toggle(new Rect(25, 125, 200, 30), useCurve, "Use Curve");
    }
}
//void Update()
//{
//    LineRenderer lineRenderer = GetComponent<LineRenderer>();
//    lineRenderer.startWidth.Equals(width);
//    lineRenderer.endWidth.Equals(width);
//    lineRenderer.positionCount.Equals(lengthOfLineRenderer);
//    //int i = 0;
//    //while (i < lengthOfLineRenderer)
//    //{
//    //    Vector3 pos = new Vector3(i * 0.5F, Mathf.Sin(i + Time.time), 0);
//    //    lineRenderer.SetPosition(i, pos);
//    //    i++;
//    //}
//}
//}

