using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.IO;

public class Plugin : MonoBehaviour
{

    [DllImport("TestDll")]
    static extern int GetID();

    [DllImport("TestDll")]
    static extern void SetID(int id);

    [DllImport("TestDll")]
    static extern Vector3 GetPosition();

    [DllImport("TestDll")]
    static extern void SetPosition(float x, float y, float z);

    [DllImport("TestDll")]
    static extern void SavePosition();

    [DllImport("TestDll")]
    static extern Color RandomColor();

    [DllImport("TestDll")]
    static extern void SaveColor();

    private Vector3 pos;
    private Color cr;

    private MeshRenderer mr;

    //Start is called before the first frame update
    void Start()
    {
        if (System.IO.File.Exists(Application.dataPath + "/position.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/position.txt");
            Debug.Log(saveString);

            for (int i = 1; i < saveString.Length; i++)
            {
                string[] array = saveString.Split(',');

                pos = new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));

                Debug.Log(pos);
            }

            transform.position = new Vector3(pos.x, pos.y, pos.z);
        }

        mr = GetComponent<MeshRenderer>();

        if (System.IO.File.Exists(Application.dataPath + "/color.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/color.txt");
            Debug.Log(saveString);

            for (int i = 1; i < saveString.Length; i++)
            {
                string[] array = saveString.Split(',');

                cr = new Color(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));

                Debug.Log(cr);
            }

            mr.material.color = new Color(cr.r, cr.g, cr.b);
        }
    }

    public void SaveMCPos()
    {
        pos = transform.position;

        SetPosition(pos.x, pos.y, pos.z);

        SavePosition();

        SaveColor();
    }

    public void RandColor()
    {
        Color rc = RandomColor();
        mr.material.color = new Color(rc.r, rc.g, rc.b);
    }
}
