using UnityEngine;

namespace CubeRain
{
	public class ColorService
	{
		public Color GetRandomColor() =>
			 new Color(Random.Range(25, 200), Random.Range(25, 200),Random.Range(25, 200), 1f);
	}
}