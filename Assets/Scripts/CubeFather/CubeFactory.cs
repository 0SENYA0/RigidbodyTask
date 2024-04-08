using System.Collections.Generic;
using UnityEngine;

namespace CubeFather
{
	public class CubeFactory
	{
		private readonly CubeFather _prefab;

		public CubeFactory(CubeFather prefab) =>
			_prefab = prefab;

		public IEnumerable<CubeFather> Create(Vector3 scale, Vector3 position, Quaternion rotation)
		{
			List<CubeFather> cubeFathers = new List<CubeFather>();
			
			for (int x = -1; x <= 1; x += 2)
			{
				for (int y = -1; y <= 1; y += 2)
				{
					for (int z = -1; z <= 1; z += 2)
					{
						position = position + new Vector3(x, y, z) * scale.x / 4;
						CubeFather cube = Object.Instantiate(_prefab, position, rotation);
						cube.Init(_prefab.PercentDuplicate / 2f);
						cube.transform.localScale = scale / 2;
						cube.GetComponent<Renderer>().material.color = GetRandomColor();
						cubeFathers.Add(cube);
					}
				}
			}
			
			return cubeFathers;
		}
		
		private Color GetRandomColor() =>
			new Color(Random.value, Random.value, Random.value);
	}
}