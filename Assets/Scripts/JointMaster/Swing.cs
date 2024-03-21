using UnityEngine;

public class Swing : MonoBehaviour
{
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private float _force;
	private void Update()
	{
		if (Input.GetKey(KeyCode.A))
			_rigidbody.AddForce(transform.right * _force);
	}
}
