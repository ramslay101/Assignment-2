using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class testsketch : MonoBehaviour {
    public GameObject myPrefab;
    public string _WebsiteURL = "http://camsbombapp.azurewebsites.net/tables/assignmentdata?zumo-api-version=2.0.0";

    void Start ()
    {
        string jsonResponse = Request.GET(_WebsiteURL);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        Product[] products = JsonReader.Deserialize<Product[]>(jsonResponse);

        int totalcubes = products.GetLength(0);

        float totaldistance = 7;
        int i = 0, j = 0, k = 0;

        //We can now loop through the array of objects and access each object individually
        foreach (Product product in products)
        {
            //Example of how to use the object
            Debug.Log("This products name is: " + product.Title);

            float perc = i /(float)totalcubes;
                float sin = Mathf.Sin(perc * Mathf.PI / 2);
                float x = 1.0f + sin * totaldistance;
                float y = 10.0f;
            if (product.ListName == "Assignment 2 (ToDo)")
            {
            perc = i / (float)totalcubes;
            i++;
            y = 13.0f;
            }else if(product.ListName == "Assignment 2 (doing)")
            {
            perc = j / (float)totalcubes;
            j++;
            y = 8.0f;
            }else
            {
            perc = k / (float)totalcubes;
            k++;
            y = 3.0f;
            }
            float z = 0.0f;


            var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
                newCube.GetComponent<CubeCode>().SetSize(1f * (1.0f - perc));
                newCube.GetComponent<CubeCode>().RotateSpeed = .8f + perc * 2.0f;
                newCube.GetComponentInChildren<TextMesh>().text = product.Title;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
