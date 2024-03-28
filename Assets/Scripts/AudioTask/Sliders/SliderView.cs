using System;
using UnityEngine;
using UnityEngine.UI;

namespace AudioTask.Sliders
{
	public class SliderView : MonoBehaviour
	{
		[SerializeField] private Slider _slider;
		private void OnEnable() =>
			_slider.onValueChanged.AddListener(OnValueChanged);

		private void OnDisable() =>
			_slider.onValueChanged.RemoveListener(OnValueChanged);

		protected virtual void OnValueChanged(float value)
		{
		}
	}
}