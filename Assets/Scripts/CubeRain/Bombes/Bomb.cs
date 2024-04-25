using System;
using System.Collections;
using UnityEngine;

namespace CubeRain
{
	public class Bomb : MonoBehaviour, IPooledObject
	{
		[SerializeField] private float _speedChangeAlpha;

		private Material _material;
		private float _targetAlpha = 0f;
		private float _epsilon = 0.1f;

		public event Action<Bomb> Destroyed;
		public event Action AlphaDecreased;

		private void OnEnable()
		{
			_material = transform.GetComponent<MeshRenderer>().material;
			StartCoroutine(DecreaseAlpha());
		}

		private IEnumerator DecreaseAlpha()
		{
			float elapsedTime = 0.0f;

			while (_material.color.a <= _epsilon == false)
			{
				elapsedTime += Time.deltaTime;

				float alpha = Mathf.Lerp(_material.color.a, _targetAlpha, elapsedTime / _speedChangeAlpha);
				_material.color = new Color(_material.color.r, _material.color.g, _material.color.b, alpha);

				yield return null;
			}
			
			AlphaDecreased?.Invoke();
			Destroyed?.Invoke(this);
		}

		public void ResetAlpha() =>
			_material.color = new Color(_material.color.r, _material.color.g, _material.color.b, 1);
	}
}