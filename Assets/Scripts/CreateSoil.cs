using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class CreateSoil : MonoBehaviour
{

	public Transform soil;
	public List<Soil> allSquares = new List<Soil> ();
	TimeManager time;
	int currentDay;
	Soil s;


	void Awake ()
	{

		DontDestroyOnLoad (this);
		if (FindObjectsOfType (GetType ()).Length > 1) {

			Destroy (this.gameObject);
		}


	}

	// Use this for initialization
	void Start ()
	{
		for (float i = 0; i <= 80; i += 10) {
			for (float j = 0; j <= 80; j += 10) {

				Transform st = Instantiate (soil.transform, new Vector3 (i, 0.1f, j), soil.transform.rotation) as Transform;
				st.SetParent (transform);
				s = new Soil (Soil.SoilTypes.NOTPLOWED, st.transform.gameObject);
				allSquares.Add (s);

			}
		}

			


	}

	void Update ()
	{



	}
		
	public List<Soil> getSoil ()
	{
		return allSquares;
	}

		
}
