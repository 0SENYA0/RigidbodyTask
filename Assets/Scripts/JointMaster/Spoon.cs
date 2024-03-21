using UnityEngine;

public class Spoon : MonoBehaviour
{
	[SerializeField] private Projectile _projectile;
	[SerializeField] private Transform _projectilePlace;
	
	public void InstanceProjectile() =>
		Instantiate(_projectile, _projectilePlace.transform.position, Quaternion.identity);
}