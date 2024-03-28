using UnityEngine;

namespace AudioTask.Buttons
{
	public class ShortAudioButtonView : ButtonView
	{
		[SerializeField] private AudioSource _audioSource;

		protected override void OnClicked()
		{
			base.OnClicked();
			_audioSource.Play();
		}
	}
}