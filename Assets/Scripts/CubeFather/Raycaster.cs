using System;
using UnityEngine;

namespace CubeFather
{
	public class Raycaster : MonoBehaviour
	{
		private Mediator _mediator;
		private void Awake() =>
			_mediator = new Mediator();

	[SerializeField] private SpriteRenderer spriteRenderer;
    private Color targetColor = Color.red;
    private Vector3 newPosition = new Vector3(2f,2f,2f);
    private Vector3 newScale;

		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(ray, out hit))
				{
					if (hit.collider.TryGetComponent(out CubeFather cubeFather))
						_mediator.Interract(cubeFather);
				}
			}
		}
	}
}