using UnityEngine;
using System.Collections;

public class sketch : MonoBehaviour
{

    public GameObject myPrefab;

    void Start()
    {
        int totalcubes = 14;

        float totaldistance = 7;
      
        for (int i = 0; i < totalcubes; i++)
        {
            float perc = i / (float)totalcubes;
            float sin = Mathf.Sin(perc * Mathf.PI/2);

            float x = 2.0f + sin * totaldistance;
            float y = 10.0f;
            float z = 0.0f;

            var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            newCube.GetComponent<CubeCode>().SetSize(1f * (1.0f - perc));
            newCube.GetComponent<CubeCode>().RotateSpeed = .2f + perc*4.0f;
        }
    }
	void Update () {
	
	}
}
