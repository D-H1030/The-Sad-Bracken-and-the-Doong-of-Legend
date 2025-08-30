using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	[Header("Settings")]
	public GameObject player;

	// Update is called once per frame
	void Update()
	{
		Vector3 playerPos = player.transform.position;
		transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
	}
}
