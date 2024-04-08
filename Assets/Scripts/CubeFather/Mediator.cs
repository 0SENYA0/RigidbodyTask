using UnityEngine;

namespace CubeFather
{
	public class Mediator
	{
		public void Interract(CubeFather cubeFather)
		{
			if (Random.Range(CubeFather.MinPercentDuplicate, CubeFather.MaxPercentDuplicate) < cubeFather.PercentDuplicate)
				Instantiate(cubeFather);
			else
				Remove(cubeFather);
		}

		private void Instantiate(CubeFather cubeFather) =>
			cubeFather.Duplicate();

		private void Remove(CubeFather cubeFather) =>
			Object.Destroy(cubeFather.gameObject);
	}
}