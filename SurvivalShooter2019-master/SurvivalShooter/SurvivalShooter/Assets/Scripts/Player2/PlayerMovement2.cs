using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
	public float speed = 6f;

	private Vector3 movement;
	private Animator anim;
	private Rigidbody playerRigidbody;
	private int floorMask;
	private float camRayLength = 100f;

	public ParticleSystem dustParticles;

	void Awake()
	{
		//dustParticles = GetComponentInChildren<ParticleSystem>();
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal2");
		float v = Input.GetAxisRaw("Vertical2");

		float t = Input.GetAxisRaw("Turning2");

		Move(h, v);
		Turning(t);
		Animating(h, v);
	}

	void Move(float h, float v)
	{
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		dustParticles.transform.position = transform.position;
		if (h != 0 || v != 0)
		{
			if (!dustParticles.isPlaying)
				dustParticles.Play();
		}

		else
		{
			dustParticles.Stop();
		}
		playerRigidbody.MovePosition(transform.position + movement);
	}

	void Turning(float t)
	{
		transform.Rotate(0, 5.0f * t, 0, Space.World);
	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;

		anim.SetBool("IsWalking", walking);
	}
}
