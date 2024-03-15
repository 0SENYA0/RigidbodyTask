using UnityEngine;

namespace Jange
{
	public class Brick : MonoBehaviour
	{
		[SerializeField] private Rigidbody _rigidbody;
		[SerializeField] private float _increaseMassStep;

		private void OnCollisionEnter(Collision collision)
		{
			Freeze();
			UnFreeze();
		}

		private void Freeze() =>
			_rigidbody.constraints = RigidbodyConstraints.FreezeAll;

		private void UnFreeze() =>
			_rigidbody.constraints = RigidbodyConstraints.None;

		public void IncreaseMass() =>
			_rigidbody.mass += _increaseMassStep;
	}
}