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
        t += 0.1f;

        // now check if the interpolator has reached 1.0 AND if max > minimum to 
		//only update map half the time 
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
		if (t > 1.0f)
        {
			if (maximum > minimum) {
				mapGenerator.seed = (int)Random.Range (-1000000f, 1000000f);
				mapGenerator.noiseScale = (int)Random.Range (20f, 80f);
				//TODO: random persisance and lacunarity, offset
				mapGenerator.GenerateMap ();
				print ("refresh \n");


			}
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}

