using System;
using UnityEngine;

namespace StalkerTask
{
	public class Stalker : MonoBehaviour
	{
		[SerializeField] private Rigidbody _rigidbody;
		[SerializeField] private Player _player;
		[SerializeField] private Collider _collider;
		[SerializeField] private float _speed;
		[SerializeField] private float _distance = 2f;

		public float minYBounds => _collider.bounds.min.y;

		public float PlayerStepOffset => _player.StepOffset;
		
		private void Update()
		{
			Vector3 direction = _player.transform.position - transform.position;
			transform.forward = direction;

			if (Vector3.Distance(_rigidbody.position, _player.transform.position) > _distance)
				_rigidbody.MovePosition(transform.position + direction * (_speed * Time.deltaTime));

		}
	}
}

