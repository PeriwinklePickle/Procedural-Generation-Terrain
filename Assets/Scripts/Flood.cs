using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flood : MonoBehaviour{
	//Reference for map generator in scene
	public MapGenerator mapGenerator;
	public TerrainType deepWater;

    // deep water terrain from .3 to 1 
    public float minimum = .3F;
    public float maximum = 1.0F;

    // starting value for the Lerp
    static float t = 0.0f;

    void Update()
    {


        // animate the position of the game object...
		mapGenerator.regions[0].height = Mathf.Lerp(minimum, maximum, t);

        // .. and increate the t interpolater
		t += (0.009f * Time.deltaTime); 

        // now check if the interpolator has reached 1.0 AND if max > minimum to 
		//only update map half the time 
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
		if (t > 1.0f)
        {
			if (maximum > minimum) {
				mapGenerator.seed = (int)Random.Range (-1000000f, 1000000f);
				//mapGenerator.noiseScale = (int)Random.Range (50f, 150f);
				//mapGenerator.persistance = (float)Random.Range (.25f,.5f);
				//mapGenerator.lacunarity = (float)Random.Range (2f,3f);
				//mapGenerator.offset.x = (float) Random.Range (-100f, 100f);
				//mapGenerator.offset.y = (float)Random.Range (-100f, 100f);
				//TODO: random persisance and lacunarity, offset
				//print ("refresh \n");


			}
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}

