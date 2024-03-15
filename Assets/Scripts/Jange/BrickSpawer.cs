using System.Collections;
using UnityEngine;

namespace Jange
{
	public class BrickSpawer : MonoBehaviour
	{
		[SerializeField] private Brick _brick;
		[SerializeField] private Transform[] _position;

		private void Start() =>
			StartCoroutine(SpawnCoroutine());

		private IEnumerator SpawnCoroutine()
		{
			while (true)
			{
				foreach (var spawnPoint in _position)
				{
					Vector3 rotation;

					if (spawnPoint.name.Contains("Up"))
						rotation = new Vector3(0, -90, 0);
					else
						rotation = Vector3.zero;

					Brick brick = Instantiate(_brick, spawnPoint.position, GetRotation(rotation));
					brick.IncreaseMass();
					yield return new WaitForSeconds(2);
				}
			}
		}

		private Quaternion GetRotation(Vector3 rotation) =>
			Quaternion.Euler(rotation);
	}
}