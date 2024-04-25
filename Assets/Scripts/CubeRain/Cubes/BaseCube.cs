using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace CubeRain
{
	public class BaseCube : MonoBehaviour, IPooledObject
	{
		private float _delay;
		private WaitForSeconds _waitForSeconds;
		private ColorService _colorService;

		private int _collisionCount;

		public event Action<BaseCube> Died;
		
		private void Awake() =>
			_colorService = new ColorService();

		private void OnEnable()
		{
			_delay = Random.Range(2f, 5f);
			_waitForSeconds = new WaitForSeconds(_delay);
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.collider.TryGetComponent(out Ground ground) && _collisionCount == 0)
			{
				_collisionCount++;
				Color color = _colorService.GetRandomColor();
				transform.GetComponent<MeshRenderer>().material.color = color;
				StartCoroutine(StartTimeToDestroy());
			}
		}

		public void Initialize(Vector3 startPosition, Color startColor)
		{
			transform.position = startPosition;
			transform.GetComponent<MeshRenderer>().material.color = startColor;
		}

		private IEnumerator StartTimeToDestroy()
		{
			yield return _waitForSeconds;
			_collisionCount = 0;
			Died?.Invoke(this);
		}
	}
}