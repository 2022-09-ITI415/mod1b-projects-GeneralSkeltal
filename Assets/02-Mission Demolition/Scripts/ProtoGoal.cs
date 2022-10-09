using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtoGoal : MonoBehaviour
{
	static public bool 	goalMet = false;
	public Text winText;


	void OnTriggerEnter(Collider other) {
		// when the trigger is hit by something
		// check to see if it's a Projectile 
		if (other.gameObject.tag == "Player") {
			// if so, set goalMet = true
			Goal.goalMet = true;
			winText.gameObject.SetActive(true);

			// also set the alpha of the color of higher opacity
			//Material mat = GetComponent<Renderer>().material;
			//Color c = mat.color;
			//c.a = 1;
			//mat.color = c;
		}
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
