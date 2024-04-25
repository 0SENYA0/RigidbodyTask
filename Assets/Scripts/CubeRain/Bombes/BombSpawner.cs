using UnityEngine;

namespace CubeRain
{
	public class BombSpawner : Spawner<Bomb>
	{
		public void Spawn(Vector3 position)
		{
			Bomb bomb = Get();
			bomb.transform.position = position;
			bomb.Destroyed += BombDestroyed;
		}

		private void BombDestroyed(Bomb bomb)
		{
			bomb.Destroyed -= BombDestroyed;
			Release(bomb);
			bomb.ResetAlpha();
		}
	}
}