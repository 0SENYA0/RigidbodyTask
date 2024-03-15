using UnityEngine;

namespace StalkerTask
{
	public class StalkerArea : MonoBehaviour
	{
		[SerializeField] private Stalker _stalker;
		private void OnTriggerEnter(Collider other)
		{
			if (other.bounds.max.y - _stalker.minYBounds >= _stalker.PlayerStepOffset)
				return;

			Vector3 position = new Vector3(_stalker.transform.position.x, other.bounds.max.y + _stalker.minYBounds + 0.1f, _stalker.transform.position.z);
			_stalker.transform.position = position;
		}
	}
}