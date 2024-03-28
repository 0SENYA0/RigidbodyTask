using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AudioTask.Sliders
{
	public class VolumeSlider : SliderView
	{
		[SerializeField] private List<AudioSource> _audioSources;
		[SerializeField] private float _speed = 1.1f;
		
		private Coroutine _coroutine;
		protected override void OnValueChanged(float value)
		{
			base.OnValueChanged(value);

			if (_coroutine != null)
				StopCoroutine(_coroutine);

			_coroutine = StartCoroutine(ChangeVolume(value));
		}

		private IEnumerator ChangeVolume(float targetValue)
		{
			while (_audioSources.All(audioSource => Mathf.Approximately(audioSource.volume, targetValue)) == false)
			{
				foreach (AudioSource audioSource in _audioSources)
					audioSource.volume = Mathf.MoveTowards(audioSource.volume, targetValue, Time.deltaTime * _speed);

				yield return null;
			}
		}
	}
}