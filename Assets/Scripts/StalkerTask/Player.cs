using UnityEngine;

namespace StalkerTask
{
	public class Player : MonoBehaviour
	{
		private const string Horizontal = "Horizontal";
		private const string Vertical = "Vertical";

		[SerializeField] private CharacterController _characterController;
		[SerializeField] private float _speed;

		public float StepOffset => _characterController.stepOffset;
		
		private void Update()
		{
			float horizontalValue = Input.GetAxis(Horizontal);
			float verticalvalue = Input.GetAxis(Vertical);
			
			_characterController.Move( Physics.gravity + transform.forward * (verticalvalue * _speed * Time.deltaTime) + transform.right * (horizontalValue * _speed * Time.deltaTime));
		}
	}
}