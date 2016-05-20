using UnityEngine;
using System.Collections;

public class sketch : MonoBehaviour {

    public GameObject myprefab;

    void Start()
    {
        int totalcubes = 8;

        int totaldistance = 10;
        for (int i = 0; i < totalcubes; i++ )
        {
            float perc = i / (float)totalcubes;
        
        float x = perc * totaldistance;
        float y = 10.0f;
        float z = 0.0f;

        var newCube = (GameObject)Instantiate(myprefab, new Vector3(x, y, z), Quaternion.identity);
        newCube.GetComponent<CubeCode>().SetSize(1.0f - perc);
        newCube.GetComponent<CubeCode>().RotateSpeed = perc;
        }
	}
	
	void Update () {
	
	}
}
