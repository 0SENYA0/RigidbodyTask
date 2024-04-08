using System;
using System.Collections.Generic;
using UnityEngine;

namespace CubeFather
{
	public class CubeFather : MonoBehaviour
	{
		public const float MaxPercentDuplicate = 1f;
		public const float MinPercentDuplicate = 0f;
		
		[SerializeField] private Rigidbody _rigidbody;
		[SerializeField] private float _explodeForce;

		public float PercentDuplicate { get; private set; } = 1f;

		private CubeFactory _cubeFactory;

		private void Awake() =>
			_cubeFactory = new CubeFactory(this);

		private void OnEnable()
		{
			Debug.Log(PercentDuplicate);
		}

		public void Init(float percentDuplicate) =>
			PercentDuplicate = percentDuplicate;

		public void Duplicate()
		{
			Vector3 forceSize =  transform.localScale;		
			Vector3 forcePosition =  transform.position;

			IEnumerable<CubeFather> cubes = _cubeFactory.Create(transform.localScale, transform.position, transform.rotation);
			
			Destroy(gameObject);

			foreach (CubeFather cube in cubes)
				cube.Explode(_explodeForce, forcePosition, forceSize.x);
		}

		private void Explode(float explodeForce, Vector3 explodePosition, float explodeRadius) =>
			_rigidbody.AddExplosionForce(explodeForce, explodePosition, explodeRadius);
	}
}