using TMPro;
using UnityEngine;

namespace CubeRain.Counters
{
	public class CounterView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _tmpText;

		private int _count;
		
		public void IncreaseCount() =>
			_tmpText.text =  $"{_count++}";
	}
}