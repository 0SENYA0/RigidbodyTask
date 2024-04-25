using System.Collections;
using CubeRain;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : Spawner<BaseCube>
{
	[SerializeField] private float _size;
	[SerializeField] private float _spawnDelay = 0.1f;
	[SerializeField] private Color _startColor;
	[SerializeField] private BombSpawner _bombSpawner;
	
	//  время между созданием кубов    
	private WaitForSeconds _waitForSeconds;
	private Vector3 _spawnPosition;
	
	private void Start()
	{
		_waitForSeconds = new WaitForSeconds(_spawnDelay);
		StartCoroutine(Spawn());
	}

	private IEnumerator Spawn()
	{
		while (true)
		{
			BaseCube cube = Get();
			cube.Died += OnCubeDied;
			cube.Initialize(GetRandomPosition(), _startColor);
			yield return _waitForSeconds;
		}
	}

	private void OnCubeDied(BaseCube cube)
	{
		cube.Died -= OnCubeDied;
		Release(cube);
		_bombSpawner.Spawn(cube.transform.position);
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