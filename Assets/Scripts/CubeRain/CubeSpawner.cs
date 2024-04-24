using System;
using System.Collections;
using CubeRain;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
	[SerializeField] private float _size;
	[SerializeField] private float _spawnDelay = 0.1f;
	[SerializeField] private Color _startColor;

	[SerializeField] private BaseCube _baseCube;

	//  время между созданием кубов    
	private WaitForSeconds _waitForSeconds;
	private ObjectPool<BaseCube> _baseCubePool;
	private Vector3 _spawnPosition;

	private void Awake()
	{
		_baseCubePool = new ObjectPool<BaseCube>(() => Instantiate(_baseCube),
			(cube) => cube.transform.gameObject.SetActive(true),
			(cube) => cube.transform.gameObject.SetActive(false),
			(cube) => Destroy(cube.transform.gameObject));

		_waitForSeconds = new WaitForSeconds(_spawnDelay);
	}

	private void Start() =>
		StartCoroutine(Spawn());

	private IEnumerator Spawn()
	{
		while (true)
		{
			BaseCube cube = _baseCubePool.Get();
			cube.Initialize(_baseCubePool, GetRandomPosition(), _startColor);
			yield return _waitForSeconds;
		}
	}

	private Vector3 GetRandomPosition()
	{
		Vector3 position = transform.position;
		_spawnPosition = new Vector3(transform.localScale.x * _size * Random.Range(0.1f, 0.6f), 1, transform.localScale.z * _size * Random.Range(0.1f, 0.6f));

		position += _spawnPosition;
		return position;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.black;

		Gizmos.DrawWireCube(transform.position, new Vector3(transform.localScale.x * _size, 1, transform.localScale.z * _size));
	}
}