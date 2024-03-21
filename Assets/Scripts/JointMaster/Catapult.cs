using System;
using UnityEngine;

public class Catapult : MonoBehaviour
{
	private const float UpBaseSpringForce = 95f;
	private const float BaseSpringForce = 60f;

	[SerializeField] private SpringJoint _springJoint;
	[SerializeField] private Rigidbody _base;
	[SerializeField] private Rigidbody _upBase;
	[SerializeField] private Spoon _spoon;

	private void OnEnable() =>
		_spoon.InstanceProjectile();

	private void Update()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			_springJoint.connectedBody = _upBase;
			_springJoint.spring = UpBaseSpringForce;
		}

		if (Input.GetKey(KeyCode.S))
		{
			_springJoint.connectedBody = _base;
			_springJoint.spring = BaseSpringForce;
			_spoon.InstanceProjectile();
		}
	}
}