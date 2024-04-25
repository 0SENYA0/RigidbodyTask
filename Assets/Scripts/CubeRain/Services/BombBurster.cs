using System;
using UnityEngine;

namespace CubeRain
{
	public class BombBurster : MonoBehaviour
	{
		[SerializeField] private float _radius;
		[SerializeField] private float _burstPower;
		[SerializeField] private float _burstDistance;
		[SerializeField] private Bomb _bomb;

		private void OnEnable() =>
			_bomb.AlphaDecreased += Burst;

		private void OnDisable() =>
			_bomb.AlphaDecreased -= Burst;

		public void Burst()
		{
			RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, _radius, Vector3.one, _burstDistance);

			foreach (RaycastHit hitInfo in raycastHits)
			{
				if (hitInfo.collider.TryGetComponent(out Rigidbody targetBody) == false)
				{
					Debug.Log("no collider " + hitInfo.collider.gameObject.name);
					continue;
				}

				Debug.Log(targetBody.gameObject.name);
				targetBody.AddForceAtPosition(Vector3.one * _burstPower, hitInfo.point, ForceMode.Force);
			}

			#region V2

			// var colliders = Physics.OverlapSphere(transform.position, _radius);
			//
			// foreach (Collider collider in colliders)
			// {
			// 	if (collider.TryGetComponent(out Rigidbody targetBody) == false)
			// 		continue;
			//
			// 	Debug.Log(targetBody.gameObject.name);
			//
			// 	Vector3 force = new Vector3(Random.Range(0.5f, 1f) * _burstPower, Random.Range(0.5f, 1f) * _burstPower, Random.Range(0.5f, 1f) * _burstPower);
			// 	targetBody.AddForce(force);
			// }

			#endregion
		}
	}
}