using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStars : MonoBehaviour
{
	private Vector2 screenBounds;
	public Camera MainCamera;
	public GameObject starPrefab;

	// Start is called before the first frame update
	void Start()
	{
		screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
		StartCoroutine(starWave());
	}

	private void spawnStar()
	{
		GameObject a = Instantiate(starPrefab) as GameObject;
		a.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y / 4, screenBounds.y / 1.2f));
	}

	IEnumerator starWave()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));
			spawnStar();
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
