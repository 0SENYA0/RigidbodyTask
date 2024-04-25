using UnityEngine;

namespace CubeRain
{
	public class ColorService
	{
		public Color GetRandomColor() =>
			 new Color(Random.Range(0f, 1f), Random.Range(0f, 1f),Random.Range(0f, 1f), 1f);
	}
}