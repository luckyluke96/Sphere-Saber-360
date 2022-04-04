using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class PeripheralSpawner : MonoBehaviour
{
    public GameObject foxRigid;
    public GameObject foxMoving;
    public GameObject fountain;
    public GameObject lamp;

    public static Vector3[] positions = { new Vector3(-13.14f, 0.109f, 2f), new Vector3(13.47f, 0.112f, 2.35f), new Vector3(11.75f, 0.24f, 9.46f), new Vector3(-13.47f, 0.712f, 6.94f) };

    public static float foxRigidAngle;
    public static float foxMovingAngle;
    public static float fountainAngle;
    public static float lampAngle;

    // Start is called before the first frame update
    void Start()
    {
        int lim = positions.Length;
        for(int i = 0; i < positions.Length; i++)
        {
            int index = Random.Range(0, positions.Length);
            Vector3 pos = positions[index];
            lim--;
            positions[index] = positions[lim];
            positions[lim] = pos;
            Debug.Log(positions[0]+","+positions[1]+","+positions[2]+","+positions[3]);
        }

        foxRigid.transform.position = positions[0];
        foxRigid.transform.Rotate(0f, Random.Range(0, 360), 0f);
        foxMoving.transform.position = positions[1];
        foxMoving.transform.Rotate(0f, Random.Range(0, 360), 0f); 
        fountain.transform.position = positions[2];
        lamp.transform.position = positions[3];

        Debug.Log("FoxRig Angle: " + calcAngle(positions[0]));
        Debug.Log("FoxMov Angle: " + calcAngle(positions[1]));
        Debug.Log("Fountain Angle: " + calcAngle(positions[2]));
        Debug.Log("Lamp Angle: " + calcAngle(positions[3]));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Method to calculate angle between x,z coordinates of vector and (0,0,1)
    /// </summary>
    /// <param name="vec1">Vector</param>
    /// <returns>Angle in degree</returns>
    float calcAngle(Vector3 vec1)
    {
        Vector2 vec = new Vector2(vec1.x, vec1.z);
        Vector2 center = new Vector2(0, 1);

        // if vec1.x < 0 object is "left" from center -> angle must be normalized
        if(vec1.x < 0)
        {
            return 360 - Vector3.SignedAngle(vec, center, Vector3.up);
        }
        else
        {
            return Vector3.SignedAngle(vec, center, Vector3.up);
        }
            
       

    }
}
