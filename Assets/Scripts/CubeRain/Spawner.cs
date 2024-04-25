using CubeRain.Counters;
using UnityEngine;
using UnityEngine.Pool;

namespace CubeRain
{
	public class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IPooledObject
	{
		[SerializeField] private T _prefab;
		[SerializeField] private CounterView _counter;

		private ObjectPool<T> _objectPool;
		
		private void Awake()
		{
			_objectPool = new ObjectPool<T>(() => Instantiate(_prefab),
				(pooledObject) => pooledObject.transform.gameObject.SetActive(true),
				(pooledObject) => pooledObject.transform.gameObject.SetActive(false),
				(pooledObject) => Destroy(pooledObject.transform.gameObject));
		}

		public void Release(T item) =>
			_objectPool.Release(item);

		public T Get()
		{
			_counter.IncreaseCount();
			return _objectPool.Get();
		}
	}
}