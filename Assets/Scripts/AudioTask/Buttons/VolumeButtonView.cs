using System.Collections.Generic;
using UnityEngine;

namespace AudioTask.Buttons
{
	public class VolumeButtonView : ButtonView
	{
		[SerializeField] private List<AudioSource> _audioSources;

		private bool _IsMute;
		
		protected override void OnClicked()
		{
			base.OnClicked();
			_IsMute = !_IsMute;

			if (_IsMute)
				ChangeVolume(_IsMute);
			else
				ChangeVolume(_IsMute);
		}

		private void ChangeVolume(bool isMute)
		{
			foreach (AudioSource audioSource in _audioSources)
				audioSource.mute = isMute;
		}
	}
}