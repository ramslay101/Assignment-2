using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour
{
    public GameObject myprefab;
    public string _WebsiteURL = "http://camsbombapp.azurewebsites.net/tables/products?zumo-api-version=2.0.0";

    void Start()
    {

        string jsonResponse = Request.GET(_WebsiteURL);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        Product[] products = JsonReader.Deserialize<Product[]>(jsonResponse);

        //----------------------
        //YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL



        //----------------------

        //We can now loop through the array of objects and access each object individually
        foreach (Product product in products)
        {
            //Example of how to use the object
            Debug.Log("This products name is: " + product.ProductName);

            int totalcubes = 8;

            int totaldistance = 10;
            for (int i = 0; i < totalcubes; i++)
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
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
